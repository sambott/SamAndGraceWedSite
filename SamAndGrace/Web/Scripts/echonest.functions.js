/**
* Functions for autocomplete using echo nest.
*/
$(function () {
    $(document).ready(function () {
        $("#trackName").val("").prop("disabled", true);
        $("#submitSuggest").prop("disabled", true);
    });

    var trackMatcher = function () {
        return function findMatches(q, cb) {
            var matches, substrRegex;
            matches = [];
            dedupe = [];
            substrRegex = new RegExp(q, 'i');
            $.each(tracks, function (i, track) {
                var lowerTitle = track.title.toLowerCase();
                if (($.inArray(lowerTitle, dedupe) == -1) && substrRegex.test(track.title)) {
                    dedupe.push(lowerTitle);
                    matches.push(track);
                }
            });
            var sortedMatches = matches.sort(function (a, b) {
                return a.title.length - b.title.length;
            });
            cb(sortedMatches);
        };
    };

    var tracks = [];

    function getArtistTracks(artistId, startIndex) {
        $.ajax({
            url: "GetEchoNestTracks",
            dataType: "json",
            data: {
                results: 100,
                format: "json",
                id: artistId,
                start: startIndex
            },
            success: function (data) {
                $.each(data.response.songs, function (i, element) {
                    tracks.push(element);
                });
                startIndex += 100;
                if (startIndex < data.response.total) {
                    getArtistTracks(artistId, startIndex);
                }
            }
        });
    }

	var echoSearch = function() {
	    return function(request, response) {
	        $.ajax({
	            url: "GetEchoNestArtists",
	            dataType: "json",
	            data: {
	                results: 12,
	                format: "json",
	                name: request,
	            },
	            success: function (data) {
	                response(data.response.artists);
	            }
	        });
	    }
	}

	$("#artistName").typeahead({
	    minLength: 3,
	    highlight: true,
	},
    {
        name: 'echoset',
        displayKey: 'name',
        source: echoSearch(),
        templates: {
            empty: "<p>No artists found</p>"
        }
    }).on('typeahead:selected', function (e, suggestion, name) {
        $("#artistId").val(suggestion.id);
        tracks = [];
        getArtistTracks(suggestion.id, 0);
        $("#trackName").attr("placeholder", "Please choose a track").prop("disabled", false);
        $("#trackName").val("")
    }).change(
        function () {
            $("#submitSuggest").prop("disabled", true);
            $("#artistId").val("");
            $("#trackName").attr("placeholder", "Please choose an artist to continue").val("").prop("disabled", true);
        }
    );

	$("#trackName").typeahead({
	    minLength: 1,
	    highlight: true,
	},
    {
        name: 'echotracks',
        displayKey: 'title',
        source: trackMatcher(),
        templates: {
            empty: "<p>No tracks found</p>"
        }
    }).on('typeahead:selected', function (e, suggestion, name) {
        $("#trackId").val(suggestion.id);
        $("#submitSuggest").prop("disabled", false);
    }).change(
        function () {
            $("#trackId").val("");
            $("#submitSuggest").prop("disabled", true);
        }
    );

});
