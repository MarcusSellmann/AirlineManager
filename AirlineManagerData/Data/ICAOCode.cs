namespace AirlineManager.Data {
    public class ICAOCode {
        #region Attributes
        char[] m_code = new char[4];
        #endregion

        #region Properties
        public string Code {
            get {
                return new string(m_code);
            }

            private set {
                if (value.Length == 4) {
                    m_code = value.ToCharArray();
                }
            }
        }

        public string Country {
            get {
                switch (m_code[0]) {
                    case 'A':
                        switch (m_code[1]) {
                            case 'G':
                                return "Salomonen";

                            case 'N':
                                return "Nauru";

                            case 'Y':
                                return "Papua - Neuguinea";

                            default:
                                return "Südwest - Pazifik";
                        }
                        
                    case 'B':
                        switch (m_code[1]) {
                            case 'G':
                                return "Grönland";

                            case 'I':
                                return "Island";

                            case 'K':
                                return "Kosovo";

                            default:
                                return "Polarregion / Südeuropa";
                        }

                    case 'C':
                        return "Kanada";

                    case 'D':
                        switch (m_code[1]) {
                            case 'A':
                                return "Algerien";

                            case 'B':
                                return "Benin";

                            case 'F':
                                return "Burkina Faso";

                            case 'G':
                                return "Ghana";

                            case 'I':
                                return "Elfenbeinküste";

                            case 'N':
                                return "Nigeria";

                            case 'R':
                                return "Niger";

                            case 'T':
                                return "Tunesien";

                            case 'X':
                                return "Togo";

                            default:
                                return "Westafrika";
                        }

                    case 'E':
                        switch (m_code[1]) {
                            case 'B':
                                return "Belgien";

                            case 'D':
                                return "Deutschland";

                            case 'E':
                                return "Estland";

                            case 'F':
                                return "Finnland";

                            case 'G':
                                return "Großbritannien";

                            case 'H':
                                return "Niederlande";

                            case 'I':
                                return "Irland";

                            case 'K':
                                return "Dänemark";

                            case 'L':
                                return "Luxemburg";

                            case 'N':
                                return "Norwegen";

                            case 'P':
                                return "Polen";

                            case 'S':
                                return "Schweden";

                            case 'T':
                                return "Deutschland";

                            case 'V':
                                return "Lettland";

                            case 'Y':
                                return "Litauen";

                            default:
                                return "Nordeuropa";
                        }

                    case 'F':
                        switch (m_code[1]) {
                            case 'A':
                                return "Südafrika";

                            case 'B':
                                return "Botswana";

                            case 'C':
                                return "Republik Kongo";

                            case 'D':
                                return "Swasiland";

                            case 'E':
                                return "Zentralafrikanische Republik";

                            case 'G':
                                return "Äquatorialguinea";

                            case 'H':
                                return "Ascension";

                            case 'I':
                                return "Mauritius";

                            case 'K':
                                return "Kamerun";

                            case 'L':
                                return "Sambia";

                            case 'M':
                                return "Komoren, Réunion und Madagaskar";

                            case 'N':
                                return "Angola";

                            case 'O':
                                return "Gabun";

                            case 'P':
                                return "São Tomé und Príncipe";

                            case 'Q':
                                return "Mosambik";

                            case 'S':
                                return "Seychellen";

                            case 'T':
                                return "Tschad";

                            case 'V':
                                return "Simbabwe";

                            case 'W':
                                return "Malawi";

                            case 'Y':
                                return "Namibia";

                            case 'X':
                                return "Lesotho";

                            case 'Z':
                                return "Demokratische Republik Kongo";

                            default:
                                return "Südliches Afrika";
                        }

                    case 'G':
                        switch (m_code[1]) {
                            case 'A':
                                return "Mali";

                            case 'B':
                                return "Gambia";

                            case 'C':
                                return "Kanarische Inseln";

                            case 'E':
                                return "Melilla und Ceuta";

                            case 'F':
                                return "Sierra Leone";

                            case 'G':
                                return "Guinea - Bissau";

                            case 'L':
                                return "Liberia";

                            case 'M':
                                return "Marokko";

                            case 'O':
                                return "Senegal";

                            case 'Q':
                                return "Mauretanien";

                            case 'S':
                                return "Westsahara";

                            case 'U':
                                return "Guinea";

                            case 'V':
                                return "Kap Verde";

                            default:
                                return "Westafrikanische Küste";
                        }

                    case 'H':
                        switch (m_code[1]) {
                            case 'A':
                                return "Äthiopien";

                            case 'B':
                                return "Burundi";

                            case 'C':
                                return "Somalia";

                            case 'D':
                                return "Dschibuti";

                            case 'E':
                                return "Ägypten";

                            case 'H':
                                return "Eritrea";

                            case 'K':
                                return "Kenia";

                            case 'L':
                                return "Libyen";

                            case 'R':
                                return "Ruanda";

                            case 'S':
                                return "Sudan";

                            case 'T':
                                return "Tansania";

                            case 'U':
                                return "Uganda";

                            default:
                                return "Ostafrika";
                        }

                    case 'K':
                        return "Kontinental - USA";

                    case 'L':
                        switch (m_code[1]) {
                            case 'A':
                                return "Albanien";

                            case 'B':
                                return "Bulgarien";

                            case 'C':
                                return "Zypern";

                            case 'D':
                                return "Kroatien";

                            case 'E':
                                return "Spanien";

                            case 'F':
                                return "Frankreich";

                            case 'G':
                                return "Griechenland";

                            case 'H':
                                return "Ungarn";

                            case 'I':
                                return "Italien";

                            case 'J':
                                return "Slowenien";

                            case 'K':
                                return "Tschechien";

                            case 'L':
                                return "Israel";

                            case 'M':
                                return "Malta";

                            case 'N':
                                return "Monaco";

                            case 'O':
                                return "Österreich";

                            case 'P':
                                return "Portugal";

                            case 'Q':
                                return "Bosnien und Herzegowina";

                            case 'R':
                                return "Rumänien";

                            case 'S':
                                return "Schweiz";

                            case 'T':
                                return "Türkei";

                            case 'U':
                                return "Moldawien";

                            case 'V':
                                return "Gazastreifen";

                            case 'W':
                                return "Mazedonien";

                            case 'X':
                                return "Gibraltar";

                            case 'Y':
                                return "Serbien und Montenegro";

                            case 'Z':
                                return "Slowakei";

                            default:
                                return "Südeuropa";
                        }

                    case 'M':
                        switch (m_code[1]) {
                            case 'B':
                                return "Turks - und Caicosinseln";

                            case 'D':
                                return "Dominikanische Republik";

                            case 'G':
                                return "Guatemala";

                            case 'H':
                                return "Honduras";

                            case 'K':
                                return "Jamaika";

                            case 'M':
                                return "Mexiko";

                            case 'N':
                                return "Nicaragua";

                            case 'P':
                                return "Panama";

                            case 'R':
                                return "Costa Rica";

                            case 'S':
                                return "El Salvador";

                            case 'T':
                                return "Haiti";

                            case 'U':
                                return "Kuba";

                            case 'W':
                                return "Kaimaninseln";

                            case 'Y':
                                return "Bahamas";

                            case 'Z':
                                return "Belize";

                            default:
                                return "Zentralamerika";
                        }

                    case 'N':
                        switch (m_code[1]) {
                            case 'C':
                                return "Cookinseln";

                            case 'F':
                                return "Fidschi und Tonga";

                            case 'G':
                                return "Kiribati und Tuvalu";

                            case 'I':
                                return "Niue";

                            case 'L':
                                return "Wallis und Futuna";

                            case 'S':
                                return "Samoa";

                            case 'T':
                                return "Polynesien";

                            case 'V':
                                return "Vanuatu";

                            case 'W':
                                return "Neukaledonien";

                            case 'Z':
                                return "Neuseeland";

                            default:
                                return "Südpazifik";
                        }

                    case 'O':
                        switch (m_code[1]) {
                            case 'A':
                                return "Afghanistan";

                            case 'B':
                                return "Bahrain";

                            case 'E':
                                return "Saudi - Arabien";

                            case 'I':
                                return "Iran";

                            case 'J':
                                return "Jordanien";

                            case 'K':
                                return "Kuwait";

                            case 'L':
                                return "Libanon";

                            case 'M':
                                return "Vereinigte Arabische Emirate";

                            case 'O':
                                return "Oman";

                            case 'P':
                                return "Pakistan";

                            case 'R':
                                return "Irak";

                            case 'S':
                                return "Syrien";

                            case 'T':
                                return "Katar";

                            case 'V':
                                return "Jemen";

                            default:
                                return "Naher Osten";
                        }

                    case 'P':
                        switch (m_code[1]) {
                            case 'A':
                                return "Alaska";

                            case 'G':
                                return "Nördliche Marianen";

                            case 'H':
                                return "Hawaii";

                            case 'J':
                                return "Johnstoninsel";

                            case 'K':
                                return "Marshallinseln";

                            case 'L':
                                return "Kiribati";

                            case 'M':
                                return "Midwayinseln";

                            case 'T':
                                return "Mikronesien";

                            case 'W':
                                return "Wake";

                            default:
                                return "Nördlicher Pazifik";
                        }

                    case 'R':
                        switch (m_code[1]) {
                            case 'C':
                                return "Republik China";

                            case 'J':
                                return "Japan";

                            case 'K':
                                return "Korea";

                            case 'O':
                                return "Japan";

                            case 'P':
                                return "Philippinen";

                            default:
                                return "Ostasien";
                        }

                    case 'S':
                        switch (m_code[1]) {
                            case 'A':
                                return "Argentinien";

                            case 'B':
                                return "Brasilien";

                            case 'C':
                                return "Chile";

                            case 'E':
                                return "Ecuador";

                            case 'F':
                                return "Falklandinseln";

                            case 'G':
                                return "Paraguay";

                            case 'K':
                                return "Kolumbien";

                            case 'L':
                                return "Bolivien";

                            case 'M':
                                return "Suriname";

                            case 'O':
                                return "Französisch - Guayana";

                            case 'P':
                                return "Peru";

                            case 'U':
                                return "Uruguay";

                            case 'V':
                                return "Venezuela";

                            case 'Y':
                                return "Guyana";

                            default:
                                return "Südamerika";
                        }

                    case 'T':
                        switch (m_code[1]) {
                            case 'A':
                                return "Antigua und Barbuda";

                            case 'B':
                                return "Barbados";

                            case 'D':
                                return "Dominica";

                            case 'F':
                                return "Französische Antillen";

                            case 'G':
                                return "Grenada";

                            case 'I':
                                return "Virgin Islands";

                            case 'J':
                                return "Puerto Rico";

                            case 'K':
                                return "St.Kitts und Nevis";

                            case 'L':
                                return "St.Lucia";

                            case 'N':
                                return "Aruba und Niederländische Antillen";

                            case 'Q':
                                return "Anguilla";

                            case 'R':
                                return "Montserrat";

                            case 'T':
                                return "Trinidad und Tobago";

                            case 'U':
                                return "Virgin Islands";

                            case 'V':
                                return "St.Vincent und die Grenadinen";

                            case 'X':
                                return "Bermuda";

                            default:
                                return "Zentralatlantik";
                        }

                    case 'U':
                        switch (m_code[1]) {
                            case 'A':
                                return "Kasachstan und Kirgisistan";

                            case 'B':
                                return "Aserbaidschan";

                            case 'D':
                                return "Armenien";

                            case 'E':
                                return "Russische Föderation";

                            case 'G':
                                return "Georgien";

                            case 'H':
                                return "Russische Föderation";

                            case 'I':
                                return "Russische Föderation";

                            case 'K':
                                return "Ukraine";

                            case 'L':
                                return "Russische Föderation";

                            case 'M':
                                return "Weißrussland";

                            case 'N':
                                return "Russische Föderation";

                            case 'O':
                                return "Russische Föderation";

                            case 'R':
                                return "Russische Föderation";

                            case 'S':
                                return "Russische Föderation";

                            case 'T':
                                return "Tadschikistan, Turkmenistan und Usbekistan";

                            case 'U':
                                return "Russische Föderation";

                            case 'W':
                                return "Russische Föderation";

                            default:
                                return "Ehemalige Sowjetunion";
                        }

                    case 'V':
                        switch (m_code[1]) {
                            case 'A':
                                return "Indien";

                            case 'C':
                                return "Sri Lanka";

                            case 'D':
                                return "Kambodscha";

                            case 'E':
                                return "Indien";

                            case 'G':
                                return "Bangladesch";

                            case 'H':
                                return "Hongkong";

                            case 'I':
                                return "Indien";

                            case 'L':
                                return "Laos";

                            case 'M':
                                return "Macau";

                            case 'N':
                                return "Nepal";

                            case 'O':
                                return "Indien";

                            case 'Q':
                                return "Bhutan";

                            case 'R':
                                return "Malediven";

                            case 'T':
                                return "Thailand";

                            case 'V':
                                return "Vietnam";

                            case 'Y':
                                return "Myanmar";

                            default:
                                return "Südasien";
                        }

                    case 'W':
                        switch (m_code[1]) {
                            case 'A':
                                return "Indonesien (Sulawesi, Irian Jaya)";

                            case 'B':
                                return "Brunei, Sabah und Sarawak (Malaysia)";

                            case 'I':
                                return "Indonesien (Java, Kalimantan)";

                            case 'M':
                                return "Malaysia (Festland)";

                            case 'P':
                                return "Osttimor";

                            case 'R':
                                return "Indonesien (Bali, Lombok, Flores)";

                            case 'S':
                                return "Singapur";

                            default:
                                return "Südostasien";
                        }

                    case 'Y':
                        return "Australien";

                    case 'Z':
                        switch (m_code[1]) {
                            case 'K':
                                return "Nordkorea";

                            case 'M':
                                return "Mongolei";

                            default:
                                return "Volksrepublik China";
                        }

                    default:
                        return "UNKNOWN";
                }
            }
        }
        #endregion

        public ICAOCode(string code) : this(code.ToCharArray()) {
        }

        public ICAOCode(char[] code) {
            m_code = new char[4];

            for (int i = 0; i < 4; ++i) {
                m_code[i] = code[i];
            }
        }

		override
		public string ToString() {
			return Code;
		}
    }
}
