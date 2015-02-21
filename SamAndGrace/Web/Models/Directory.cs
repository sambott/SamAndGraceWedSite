using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Web.Models
{
    public class Directory
    {
        private static volatile Directory s_instance;
        private static readonly object s_syncRoot = new Object();
        private readonly List<BAndB> m_bAndBs;
        private readonly List<Hotel> m_hotels;
        private readonly List<Taxi> m_taxis;

        private Directory()
        {
            #region populate hotels

            m_hotels = new List<Hotel>
            {
                new Hotel
                {
                    Location = "Bicester",
                    DriveDistanceMinutes = 5,
                    Name = "Almond Tree",
                    NumberOfRooms = 18,
                    Url = new Url("http://www.almondtreehotel.co.uk"),
                    PhoneNumber = "01869 360629"
                },
                new Hotel
                {
                    Location = "Bicester",
                    DriveDistanceMinutes = 5,
                    Name = "Littlebury",
                    StarRating = 3,
                    NumberOfRooms = 41,
                    Url = new Url("http://www.littleburyhotel.com"),
                    PhoneNumber = "01869 252595"
                },
                new Hotel
                {
                    Location = "Bicester",
                    DriveDistanceMinutes = 5,
                    Name = "Premier Inn",
                    NumberOfRooms = 84,
                    Url = new Url("http://www.premierinn.com"),
                    PhoneNumber = "0871 5279394"
                },
                new Hotel
                {
                    Location = "Arncott",
                    DriveDistanceMinutes = 10,
                    Name = "The Tally Ho",
                    StarRating = 3,
                    NumberOfRooms = 26,
                    Url = new Url("http://www.tallyhotel.com"),
                    PhoneNumber = "01869 247170"
                },
                new Hotel
                {
                    Location = "Chesterton",
                    DriveDistanceMinutes = 10,
                    Name = "Bicester Hotel, Golf & Spa",
                    StarRating = 4,
                    NumberOfRooms = 52,
                    Url = new Url("http://www.bicesterhotelgolfandspa.co.uk"),
                    PhoneNumber = "01869 241204"
                },
                new Hotel
                {
                    Location = "Chesterton",
                    DriveDistanceMinutes = 10,
                    Name = "Bignell Park Hotel",
                    StarRating = 3,
                    NumberOfRooms = 22,
                    Url = new Url("http://www.bignellparkhotel.co.uk"),
                    PhoneNumber = "01869 326550"
                },
                new Hotel
                {
                    Location = "Ardley ",
                    DriveDistanceMinutes = 15,
                    Name = "Travelodge",
                    StarRating = 3,
                    NumberOfRooms = 133,
                    Url = new Url("http://www.travelodge.co.uk"),
                    PhoneNumber = "01869 346137"
                },
                new Hotel
                {
                    Location = "Middleton Stoney",
                    DriveDistanceMinutes = 15,
                    Name = "Jersey Arms",
                    StarRating = 2,
                    NumberOfRooms = 20,
                    Url = new Url("http://www.jerseyarms.co.uk"),
                    PhoneNumber = "01869 343234"
                },
                new Hotel
                {
                    Location = "Weston-On-The-Green",
                    DriveDistanceMinutes = 15,
                    Name = "The Manor Hotel",
                    StarRating = 3,
                    NumberOfRooms = 35,
                    Url = new Url("http://www.themanorweston.com"),
                    PhoneNumber = "01869 350621"
                },
                new Hotel
                {
                    Location = "Aynho",
                    DriveDistanceMinutes = 20,
                    Name = "Cartwright Hotel",
                    StarRating = 3,
                    NumberOfRooms = 21,
                    Url = new Url("http://www.cartwright-hotel.co.uk"),
                    PhoneNumber = "01869 811885"
                },
                new Hotel
                {
                    Location = "Kirtlington",
                    DriveDistanceMinutes = 20,
                    Name = "The Dashwood",
                    StarRating = 3,
                    NumberOfRooms = 12,
                    Url = new Url("http://www.thedashwood.co.uk"),
                    PhoneNumber = "01869 352707"
                },
                new Hotel
                {
                    Location = "Oxford",
                    DriveDistanceMinutes = 20,
                    Name = "Holiday Inn",
                    StarRating = 4,
                    NumberOfRooms = 154,
                    Url = new Url("http://www.holidayinn.com"),
                    PhoneNumber = "08700 850950"
                },
                new Hotel
                {
                    Location = "Oxford",
                    DriveDistanceMinutes = 20,
                    Name = "Travelodge",
                    NumberOfRooms = 140,
                    Url = new Url("http://www.travelodge.co.uk"),
                    PhoneNumber = "0871 9846206"
                },
                new Hotel
                {
                    Location = "Steeple Aston",
                    DriveDistanceMinutes = 20,
                    Name = "The Holt",
                    StarRating = 3,
                    NumberOfRooms = 86,
                    Url = new Url("http://www.holthotel.co.uk"),
                    PhoneNumber = "01869 340259"
                },
                new Hotel
                {
                    Location = "Waddesdon",
                    DriveDistanceMinutes = 20,
                    Name = "The Five Arrows Hotel",
                    StarRating = 4,
                    NumberOfRooms = 11,
                    Url = new Url("http://www.waddesdon.org.uk/five-arrows"),
                    PhoneNumber = "01296 651727"
                }
            };

            #endregion

            #region populate b and bs

            m_bAndBs = new List<BAndB>
            {
                new BAndB
                {
                    Location = "Bicester",
                    DriveDistanceMinutes = 5,
                    Name = "Priory House",
                    PhoneNumber = "01869 325687"
                },
                new BAndB
                {
                    Location = "Bicester",
                    DriveDistanceMinutes = 5,
                    Name = "The Swan",
                    Url = new Url("http://www.theswanbicester.co.uk"),
                    PhoneNumber = "01869 369035"
                },
                new BAndB
                {
                    Location = "Blackthorn",
                    DriveDistanceMinutes = 5,
                    Name = "Lime Trees Farm",
                    Url = new Url("http://www.limetreesfarm.co.uk"),
                    PhoneNumber = "01869 248435"
                },
                new BAndB
                {
                    Location = "Marsh Gibbon",
                    DriveDistanceMinutes = 5,
                    Name = "Judges Close",
                    PhoneNumber = "01869 278508"
                },
                new BAndB
                {
                    Location = "Marsh Gibbon",
                    DriveDistanceMinutes = 5,
                    Name = "Spiers Court",
                    PhoneNumber = "01869 277556"
                },
                new BAndB
                {
                    Location = "Hethe",
                    DriveDistanceMinutes = 10,
                    Name = "Manor Farm",
                    StarRating = 4,
                    PhoneNumber = "01869 277602"
                },
                new BAndB
                {
                    Location = "Stratton Audley",
                    DriveDistanceMinutes = 10,
                    Name = "Orchard House",
                    PhoneNumber = "01869 277427"
                },
                new BAndB
                {
                    Location = "Stratton Audley",
                    DriveDistanceMinutes = 10,
                    Name = "West Farm",
                    Url = new Url("http://www.westfarmbb.co.uk"),
                    PhoneNumber = "01869 278344"
                },
                new BAndB
                {
                    Location = "Stratton Audley",
                    DriveDistanceMinutes = 10,
                    Name = "The Old School",
                    Url = new Url("http://www.old-school.co.uk"),
                    PhoneNumber = "01869 277371"
                },
                new BAndB
                {
                    Location = "Ardley",
                    DriveDistanceMinutes = 15,
                    Name = "OldPostOffice",
                    StarRating = 3,
                    Url = new Url("http://www.theoldpostofficeardley.co.uk"),
                    PhoneNumber = "01869 345958"
                },
                new BAndB
                {
                    Location = "Weston-On-The-Green",
                    DriveDistanceMinutes = 15,
                    Name = "Weston Grounds Farm",
                    StarRating = 3,
                    PhoneNumber = "01869 351168"
                },
                new BAndB
                {
                    Location = "Little Chesterton",
                    DriveDistanceMinutes = 20,
                    Name = "Cover Point",
                    PhoneNumber = "01869 252500"
                },
                new BAndB
                {
                    Location = "Souldern",
                    DriveDistanceMinutes = 20,
                    Name = "The Fox",
                    Url = new Url("http://www.thefoxatsouldern.co.uk"),
                    PhoneNumber = "01869 345284"
                },
                new BAndB
                {
                    Location = "Wendlebury",
                    DriveDistanceMinutes = 20,
                    Name = "Merton Grounds",
                    Url = new Url("http://www.mertongrounds.co.uk"),
                    PhoneNumber = "07785363636"
                },
                new BAndB
                {
                    Location = "Waddlesdon",
                    DriveDistanceMinutes = 20,
                    Name = "The Lion",
                    Url = new Url("http://www.thelionwaddlesdon.co.uk"),
                    PhoneNumber = "01296 651227"
                }
            };

            #endregion

            #region populate taxis

            m_taxis = new List<Taxi>
            {
                new Taxi
                {
                    Location = "Bicester",
                    Name = "Alpha Cars",
                    PhoneNumber = "01869 242424",
                },
                new Taxi
                {
                    Location = "Bicester",
                    Name = "Future Cars",
                    PhoneNumber = "01869 327711",
                },
                new Taxi
                {
                    Location = "Bicester",
                    Name = "QC Taxis",
                    PhoneNumber = "01869 246678",
                    HasPeopleCarriers = true,
                },
                new Taxi
                {
                    Location = "Bicester",
                    Name = "ABC Taxis",
                    PhoneNumber = "01869 242601",
                },
                new Taxi
                {
                    Location = "Bicester",
                    Name = "Star Cars",
                    PhoneNumber = "01869 252526",
                },
                new Taxi
                {
                    Location = "Oxford",
                    Name = "Radio Taxis",
                    PhoneNumber = "01865 242424",
                    HasPeopleCarriers = true,
                },
                new Taxi
                {
                    Location = "Oxford",
                    Name = "Royal Cars",
                    PhoneNumber = "01865 777333",
                    HasPeopleCarriers = true,
                },
                new Taxi
                {
                    Location = "Oxford",
                    Name = "ABC Taxis",
                    PhoneNumber = "01865 770077",
                    HasPeopleCarriers = true,
                },
                new Taxi
                {
                    Location = "Oxford",
                    Name = "K Cars",
                    PhoneNumber = "01865 377313",
                },
                new Taxi
                {
                    Location = "Banbury",
                    Name = "Airport Cars",
                    PhoneNumber = "01295 272728",
                    HasPeopleCarriers = true,
                },
                new Taxi
                {
                    Location = "Banbury",
                    Name = "Banbury Taxis",
                    PhoneNumber = "01295 272727",
                    HasPeopleCarriers = true,
                },
                new Taxi
                {
                    Location = "Aylesbury",
                    Name = "Braziers",
                    PhoneNumber = "01296 712201",
                    HasPeopleCarriers = true,
                }
            };

            #endregion

            m_bAndBs = new List<BAndB>();
        }

        public List<Hotel> Hotels
        {
            get { return m_hotels; }
        }

        public List<BAndB> BAndBs
        {
            get { return m_bAndBs; }
        }

        public List<Taxi> Taxis
        {
            get { return m_taxis; }
        }

        public static Directory Instance
        {
            get
            {
                if (s_instance != null) return s_instance;
                lock (s_syncRoot)
                {
                    if (s_instance == null)
                        s_instance = new Directory();
                }

                return s_instance;
            }
        }
    }
}