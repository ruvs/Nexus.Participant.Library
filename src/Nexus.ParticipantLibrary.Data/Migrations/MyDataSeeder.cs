using Microsoft.EntityFrameworkCore.Migrations;
using Nexus.ParticipantLibrary.Data.Domain;
using System.Collections.Generic;

namespace Nexus.ParticipantLibrary.Data.Migrations
{
    public class MyDataSeeder
    {
        public MyDataSeeder()
        {

        }
        public static void SeedTheInitialData(MigrationBuilder migrationBuilder)
        {
            var plitItems = new List<ParticipantLibraryItemType>();
            plitItems.Add(new ParticipantLibraryItemType { Name = "COUNTRY", DisplayName = "Country" });
            plitItems.Add(new ParticipantLibraryItemType { Name = "TEAM", DisplayName = "Team" });
            plitItems.Add(new ParticipantLibraryItemType { Name = "INDIVIDUAL", DisplayName = "Individual" });

            foreach (var plit in plitItems)
            {
                migrationBuilder.Sql($"IF NOT EXISTS (SELECT * FROM dbo.[ParticipantLibraryItemType] WHERE [Name] = '{plit.Name}') BEGIN INSERT INTO[dbo].[ParticipantLibraryItemType] ([NexusKey],[Name], [DisplayName]) VALUES (NEWID(),'{plit.Name}','{plit.DisplayName}') END");
                migrationBuilder.Sql($"IF NOT EXISTS (SELECT * FROM dbo.[ParticipantLibraryItemType] WHERE [Name] = '{plit.Name}') BEGIN INSERT INTO[dbo].[ParticipantLibraryItemType] ([NexusKey],[Name], [DisplayName]) VALUES (NEWID(),'{plit.Name}','{plit.DisplayName}') END");
                migrationBuilder.Sql($"IF NOT EXISTS (SELECT * FROM dbo.[ParticipantLibraryItemType] WHERE [Name] = '{plit.Name}') BEGIN INSERT INTO[dbo].[ParticipantLibraryItemType] ([NexusKey],[Name], [DisplayName]) VALUES (NEWID(),'{plit.Name}','{plit.DisplayName}') END");
            }

            var pliItems = new List<ParticipantLibraryItem>();
            #region countries
            pliItems.Add(new ParticipantLibraryItem { Name = "AFG", DisplayName = "Afghanistan", DisplayCode = "AFG", Iso3Code = "AFG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AIA", DisplayName = "Anguilla", DisplayCode = "AIA", Iso3Code = "AIA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ALB", DisplayName = "Albania", DisplayCode = "ALB", Iso3Code = "ALB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ALG", DisplayName = "Algeria", DisplayCode = "ALG", Iso3Code = "DZA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AND", DisplayName = "Andorra", DisplayCode = "AND", Iso3Code = "AND" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ANG", DisplayName = "Angola", DisplayCode = "ANG", Iso3Code = "AGO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ARG", DisplayName = "Argentina", DisplayCode = "ARG", Iso3Code = "ARG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ARM", DisplayName = "Armenia", DisplayCode = "ARM", Iso3Code = "ARM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ARU", DisplayName = "Aruba", DisplayCode = "ARU", Iso3Code = "ABW" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ASA", DisplayName = "American Samoa", DisplayCode = "ASA", Iso3Code = "ASM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ATG", DisplayName = "Antigua and Barbuda", DisplayCode = "ATG", Iso3Code = "ATG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AUS", DisplayName = "Australia", DisplayCode = "AUS", Iso3Code = "AUS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AUT", DisplayName = "Austria", DisplayCode = "AUT", Iso3Code = "AUT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AZE", DisplayName = "Azerbaijan", DisplayCode = "AZE", Iso3Code = "AZE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BAH", DisplayName = "The Bahamas", DisplayCode = "BAH", Iso3Code = "BHS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BAN", DisplayName = "Bangladesh", DisplayCode = "BAN", Iso3Code = "BGD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BDI", DisplayName = "Burundi", DisplayCode = "BDI", Iso3Code = "BDI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BEL", DisplayName = "Belgium", DisplayCode = "BEL", Iso3Code = "BEL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BEN", DisplayName = "Benin", DisplayCode = "BEN", Iso3Code = "BEN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BER", DisplayName = "Bermuda", DisplayCode = "BER", Iso3Code = "BMU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BFA", DisplayName = "Burkina Faso", DisplayCode = "BFA", Iso3Code = "BFA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BHR", DisplayName = "Bahrain", DisplayCode = "BHR", Iso3Code = "BHR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BHU", DisplayName = "Bhutan", DisplayCode = "BHU", Iso3Code = "BTN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BIH", DisplayName = "Bosnia and Herzegovina", DisplayCode = "BIH", Iso3Code = "BIH" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BLR", DisplayName = "Belarus", DisplayCode = "BLR", Iso3Code = "BLR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BLZ", DisplayName = "Belize", DisplayCode = "BLZ", Iso3Code = "BLZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BOL", DisplayName = "Bolivia", DisplayCode = "BOL", Iso3Code = "BOL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BOT", DisplayName = "Botswana", DisplayCode = "BOT", Iso3Code = "BWA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BRA", DisplayName = "Brazil", DisplayCode = "BRA", Iso3Code = "BRA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BRB", DisplayName = "Barbados", DisplayCode = "BRB", Iso3Code = "BRB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BRU", DisplayName = "Brunei", DisplayCode = "BRU", Iso3Code = "BRN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BUL", DisplayName = "Bulgaria", DisplayCode = "BUL", Iso3Code = "BGR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CAM", DisplayName = "Cambodia", DisplayCode = "CAM", Iso3Code = "KHM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CAN", DisplayName = "Canada", DisplayCode = "CAN", Iso3Code = "CAN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CAY", DisplayName = "Cayman Islands", DisplayCode = "CAY", Iso3Code = "CYM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CGO", DisplayName = "Congo", DisplayCode = "CGO", Iso3Code = "COG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CHA", DisplayName = "Chad", DisplayCode = "CHA", Iso3Code = "TCD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CHI", DisplayName = "Chile", DisplayCode = "CHI", Iso3Code = "CHL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CHN", DisplayName = "China", DisplayCode = "CHN", Iso3Code = "CHN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CIV", DisplayName = "Côte d''Ivoire", DisplayCode = "CIV", Iso3Code = "CIV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CMR", DisplayName = "Cameroon", DisplayCode = "CMR", Iso3Code = "CMR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "COK", DisplayName = "Cook Islands", DisplayCode = "COK", Iso3Code = "COK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "COL", DisplayName = "Colombia", DisplayCode = "COL", Iso3Code = "COL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "COM", DisplayName = "Comoros", DisplayCode = "COM", Iso3Code = "COM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CPV", DisplayName = "Cape Verde", DisplayCode = "CPV", Iso3Code = "CPV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CRC", DisplayName = "Costa Rica", DisplayCode = "CRC", Iso3Code = "CRI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CRO", DisplayName = "Croatia", DisplayCode = "CRO", Iso3Code = "HRV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CTA", DisplayName = "Central African Republic", DisplayCode = "CTA", Iso3Code = "CAF" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CUB", DisplayName = "Cuba", DisplayCode = "CUB", Iso3Code = "CUB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CUW", DisplayName = "Curaçao", DisplayCode = "CUW", Iso3Code = "CUW" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CYP", DisplayName = "Cyprus", DisplayCode = "CYP", Iso3Code = "CYP" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CZE", DisplayName = "Czech Republic", DisplayCode = "CZE", Iso3Code = "CZE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "DEN", DisplayName = "Denmark", DisplayCode = "DEN", Iso3Code = "DNK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "DJI", DisplayName = "Djibouti", DisplayCode = "DJI", Iso3Code = "DJI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "DMA", DisplayName = "Dominica", DisplayCode = "DMA", Iso3Code = "DMA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "DOM", DisplayName = "Dominican Republic", DisplayCode = "DOM", Iso3Code = "DOM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ECU", DisplayName = "Ecuador", DisplayCode = "ECU", Iso3Code = "ECU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "EGY", DisplayName = "Egypt", DisplayCode = "EGY", Iso3Code = "EGY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ENG", DisplayName = "England", DisplayCode = "ENG", Iso3Code = "ENG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "EQG", DisplayName = "Equatorial Guinea", DisplayCode = "EQG", Iso3Code = "GNQ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ERI", DisplayName = "Eritrea", DisplayCode = "ERI", Iso3Code = "ERI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ESP", DisplayName = "Spain", DisplayCode = "ESP", Iso3Code = "ESP" });
            pliItems.Add(new ParticipantLibraryItem { Name = "EST", DisplayName = "Estonia", DisplayCode = "EST", Iso3Code = "EST" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ETH", DisplayName = "Ethiopia", DisplayCode = "ETH", Iso3Code = "ETH" });
            pliItems.Add(new ParticipantLibraryItem { Name = "FIJ", DisplayName = "Fiji", DisplayCode = "FIJ", Iso3Code = "FJI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "FIN", DisplayName = "Finland", DisplayCode = "FIN", Iso3Code = "FIN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "FRA", DisplayName = "France", DisplayCode = "FRA", Iso3Code = "FRA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "FRO", DisplayName = "Faroe Islands", DisplayCode = "FRO", Iso3Code = "FRO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GAB", DisplayName = "Gabon", DisplayCode = "GAB", Iso3Code = "GAB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GAM", DisplayName = "The Gambia", DisplayCode = "GAM", Iso3Code = "GMB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GBR", DisplayName = "United Kingdom", DisplayCode = "GBR", Iso3Code = "GBR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GEO", DisplayName = "Georgia", DisplayCode = "GEO", Iso3Code = "GEO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GER", DisplayName = "Germany", DisplayCode = "GER", Iso3Code = "DEU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GHA", DisplayName = "Ghana", DisplayCode = "GHA", Iso3Code = "GHA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GIB", DisplayName = "Gibraltar", DisplayCode = "GIB", Iso3Code = "GIB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GNB", DisplayName = "Guinea-Bissau", DisplayCode = "GNB", Iso3Code = "GNB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GRE", DisplayName = "Greece", DisplayCode = "GRE", Iso3Code = "GRC" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GRN", DisplayName = "Grenada", DisplayCode = "GRN", Iso3Code = "GRD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GUA", DisplayName = "Guatemala", DisplayCode = "GUA", Iso3Code = "GTM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GUI", DisplayName = "Guinea", DisplayCode = "GUI", Iso3Code = "GIN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GUM", DisplayName = "Guam", DisplayCode = "GUM", Iso3Code = "GUM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GUY", DisplayName = "Guyana", DisplayCode = "GUY", Iso3Code = "GUY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "HAI", DisplayName = "Haiti", DisplayCode = "HAI", Iso3Code = "HTI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "HKG", DisplayName = "Hong Kong", DisplayCode = "HKG", Iso3Code = "HKG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "HON", DisplayName = "Honduras", DisplayCode = "HON", Iso3Code = "HND" });
            pliItems.Add(new ParticipantLibraryItem { Name = "HUN", DisplayName = "Hungary", DisplayCode = "HUN", Iso3Code = "HUN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IDN", DisplayName = "Indonesia", DisplayCode = "IDN", Iso3Code = "IDN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IND", DisplayName = "India", DisplayCode = "IND", Iso3Code = "IND" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IRL", DisplayName = "Ireland", DisplayCode = "IRL", Iso3Code = "IRL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IRN", DisplayName = "Iran", DisplayCode = "IRN", Iso3Code = "IRN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IRQ", DisplayName = "Iraq", DisplayCode = "IRQ", Iso3Code = "IRQ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ISL", DisplayName = "Iceland", DisplayCode = "ISL", Iso3Code = "ISL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ISR", DisplayName = "Israel", DisplayCode = "ISR", Iso3Code = "ISR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ITA", DisplayName = "Italy", DisplayCode = "ITA", Iso3Code = "ITA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "JAM", DisplayName = "Jamaica", DisplayCode = "JAM", Iso3Code = "JAM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "JOR", DisplayName = "Jordan", DisplayCode = "JOR", Iso3Code = "JOR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "JPN", DisplayName = "Japan", DisplayCode = "JPN", Iso3Code = "JPN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KAZ", DisplayName = "Kazakhstan", DisplayCode = "KAZ", Iso3Code = "KAZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KEN", DisplayName = "Kenya", DisplayCode = "KEN", Iso3Code = "KEN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KGZ", DisplayName = "Kyrgyzstan", DisplayCode = "KGZ", Iso3Code = "KGZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KOR", DisplayName = "South Korea", DisplayCode = "KOR", Iso3Code = "KOR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KSA", DisplayName = "Saudi Arabia", DisplayCode = "KSA", Iso3Code = "SAU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KUW", DisplayName = "Kuwait", DisplayCode = "KUW", Iso3Code = "KWT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KVX", DisplayName = "ovo", DisplayCode = "KVX", Iso3Code = "|Ko" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LAO", DisplayName = "Laos", DisplayCode = "LAO", Iso3Code = "LAO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LBR", DisplayName = "Liberia", DisplayCode = "LBR", Iso3Code = "LBR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LBY", DisplayName = "Libya", DisplayCode = "LBY", Iso3Code = "LBY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LCA", DisplayName = "Saint Lucia", DisplayCode = "LCA", Iso3Code = "LCA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LES", DisplayName = "Lesotho", DisplayCode = "LES", Iso3Code = "LSO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LIB", DisplayName = "Lebanon", DisplayCode = "LIB", Iso3Code = "LBN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LIE", DisplayName = "Liechtenstein", DisplayCode = "LIE", Iso3Code = "LIE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LTU", DisplayName = "Lithuania", DisplayCode = "LTU", Iso3Code = "LTU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LUX", DisplayName = "Luxembourg", DisplayCode = "LUX", Iso3Code = "LUX" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LVA", DisplayName = "Latvia", DisplayCode = "LVA", Iso3Code = "LVA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MAC", DisplayName = "Macau", DisplayCode = "MAC", Iso3Code = "MAC" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MAD", DisplayName = "Madagascar", DisplayCode = "MAD", Iso3Code = "MDG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MAR", DisplayName = "Morocco", DisplayCode = "MAR", Iso3Code = "MAR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MAS", DisplayName = "Malaysia", DisplayCode = "MAS", Iso3Code = "MYS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MDA", DisplayName = "Moldova", DisplayCode = "MDA", Iso3Code = "MDA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MDV", DisplayName = "Maldives", DisplayCode = "MDV", Iso3Code = "MDV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MEX", DisplayName = "Mexico", DisplayCode = "MEX", Iso3Code = "MEX" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MGL", DisplayName = "Mongolia", DisplayCode = "MGL", Iso3Code = "MNG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MKD", DisplayName = "Macedonia", DisplayCode = "MKD", Iso3Code = "MKD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MLI", DisplayName = "Mali", DisplayCode = "MLI", Iso3Code = "MLI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MLT", DisplayName = "Malta", DisplayCode = "MLT", Iso3Code = "MLT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MNE", DisplayName = "Montenegro", DisplayCode = "MNE", Iso3Code = "MNE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MOZ", DisplayName = "Mozambique", DisplayCode = "MOZ", Iso3Code = "MOZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MRI", DisplayName = "Mauritius", DisplayCode = "MRI", Iso3Code = "MUS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MSR", DisplayName = "Montserrat", DisplayCode = "MSR", Iso3Code = "MSR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MTN", DisplayName = "Mauritania", DisplayCode = "MTN", Iso3Code = "MRT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MWI", DisplayName = "Malawi", DisplayCode = "MWI", Iso3Code = "MWI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MYA", DisplayName = "Myanmar", DisplayCode = "MYA", Iso3Code = "MMR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NAM", DisplayName = "Namibia", DisplayCode = "NAM", Iso3Code = "NAM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NCA", DisplayName = "Nicaragua", DisplayCode = "NCA", Iso3Code = "NIC" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NCL", DisplayName = "New Caledonia", DisplayCode = "NCL", Iso3Code = "NCL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NED", DisplayName = "Netherlands", DisplayCode = "NED", Iso3Code = "NLD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NEP", DisplayName = "Nepal", DisplayCode = "NEP", Iso3Code = "NPL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NGA", DisplayName = "Nigeria", DisplayCode = "NGA", Iso3Code = "NGA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NIG", DisplayName = "Niger", DisplayCode = "NIG", Iso3Code = "NER" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NIR", DisplayName = "Northern Ireland", DisplayCode = "NIR", Iso3Code = "NIR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NOR", DisplayName = "Norway", DisplayCode = "NOR", Iso3Code = "NOR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NZL", DisplayName = "New Zealand", DisplayCode = "NZL", Iso3Code = "NZL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "OMA", DisplayName = "Oman", DisplayCode = "OMA", Iso3Code = "OMN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PAK", DisplayName = "Pakistan", DisplayCode = "PAK", Iso3Code = "PAK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PAN", DisplayName = "Panama", DisplayCode = "PAN", Iso3Code = "PAN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PAR", DisplayName = "Paraguay", DisplayCode = "PAR", Iso3Code = "PRY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PER", DisplayName = "Peru", DisplayCode = "PER", Iso3Code = "PER" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PHI", DisplayName = "Philippines", DisplayCode = "PHI", Iso3Code = "PHL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PLE", DisplayName = "State of Palestine", DisplayCode = "PLE", Iso3Code = "PSE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PNG", DisplayName = "Papua New Guinea", DisplayCode = "PNG", Iso3Code = "PNG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "POL", DisplayName = "Poland", DisplayCode = "POL", Iso3Code = "POL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "POR", DisplayName = "Portugal", DisplayCode = "POR", Iso3Code = "PRT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PRK", DisplayName = "North Korea", DisplayCode = "PRK", Iso3Code = "PRK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PUR", DisplayName = "Puerto Rico", DisplayCode = "PUR", Iso3Code = "PRI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "QAT", DisplayName = "Qatar", DisplayCode = "QAT", Iso3Code = "QAT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ROU", DisplayName = "Romania", DisplayCode = "ROU", Iso3Code = "ROU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "RSA", DisplayName = "South Africa", DisplayCode = "RSA", Iso3Code = "ZAF" });
            pliItems.Add(new ParticipantLibraryItem { Name = "RUS", DisplayName = "Russian Federation", DisplayCode = "RUS", Iso3Code = "RUS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "RWA", DisplayName = "Rwanda", DisplayCode = "RWA", Iso3Code = "RWA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SAM", DisplayName = "Samoa", DisplayCode = "SAM", Iso3Code = "WSM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SCO", DisplayName = "Scotland", DisplayCode = "SCO", Iso3Code = "SCO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SDN", DisplayName = "Sudan", DisplayCode = "SDN", Iso3Code = "SDN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SEN", DisplayName = "Senegal", DisplayCode = "SEN", Iso3Code = "SEN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SEY", DisplayName = "Seychelles", DisplayCode = "SEY", Iso3Code = "SYC" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SIN", DisplayName = "Singapore", DisplayCode = "SIN", Iso3Code = "SGP" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SKN", DisplayName = "Saint Kitts and Nevis", DisplayCode = "SKN", Iso3Code = "KNA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SLE", DisplayName = "Sierra Leone", DisplayCode = "SLE", Iso3Code = "SLE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SLV", DisplayName = "El Salvador", DisplayCode = "SLV", Iso3Code = "SLV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SMR", DisplayName = "San Marino", DisplayCode = "SMR", Iso3Code = "SMR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SOL", DisplayName = "Solomon Islands", DisplayCode = "SOL", Iso3Code = "SLB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SOM", DisplayName = "Somalia", DisplayCode = "SOM", Iso3Code = "SOM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SRB", DisplayName = "Serbia", DisplayCode = "SRB", Iso3Code = "SRB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SRI", DisplayName = "Sri Lanka", DisplayCode = "SRI", Iso3Code = "LKA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SSD", DisplayName = "South Sudan", DisplayCode = "SSD", Iso3Code = "SSD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "STP", DisplayName = "São Tomé and Príncipe", DisplayCode = "STP", Iso3Code = "STP" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SUI", DisplayName = "Switzerland", DisplayCode = "SUI", Iso3Code = "CHE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SUR", DisplayName = "Suriname", DisplayCode = "SUR", Iso3Code = "SUR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SVK", DisplayName = "Slovakia", DisplayCode = "SVK", Iso3Code = "SVK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SVN", DisplayName = "Slovenia", DisplayCode = "SVN", Iso3Code = "SVN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SWE", DisplayName = "Sweden", DisplayCode = "SWE", Iso3Code = "SWE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SWZ", DisplayName = "Swaziland", DisplayCode = "SWZ", Iso3Code = "SWZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SYR", DisplayName = "Syria", DisplayCode = "SYR", Iso3Code = "SYR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TAH", DisplayName = "French Polynesia", DisplayCode = "TAH", Iso3Code = "PYF" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TAN", DisplayName = "Tanzania", DisplayCode = "TAN", Iso3Code = "TZA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TCA", DisplayName = "Turks and Caicos Islands", DisplayCode = "TCA", Iso3Code = "TCA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TGA", DisplayName = "Tonga", DisplayCode = "TGA", Iso3Code = "TON" });
            pliItems.Add(new ParticipantLibraryItem { Name = "THA", DisplayName = "Thailand", DisplayCode = "THA", Iso3Code = "THA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TJK", DisplayName = "Tajikistan", DisplayCode = "TJK", Iso3Code = "TJK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TKM", DisplayName = "Turkmenistan", DisplayCode = "TKM", Iso3Code = "TKM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TLS", DisplayName = "Timor-Leste", DisplayCode = "TLS", Iso3Code = "TLS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TOG", DisplayName = "Togo", DisplayCode = "TOG", Iso3Code = "TGO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TPE", DisplayName = "Taiwan", DisplayCode = "TPE", Iso3Code = "TWN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TRI", DisplayName = "Trinidad and Tobago", DisplayCode = "TRI", Iso3Code = "TTO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TUN", DisplayName = "Tunisia", DisplayCode = "TUN", Iso3Code = "TUN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TUR", DisplayName = "Turkey", DisplayCode = "TUR", Iso3Code = "TUR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "UAE", DisplayName = "United Arab Emirates", DisplayCode = "UAE", Iso3Code = "ARE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "UGA", DisplayName = "Uganda", DisplayCode = "UGA", Iso3Code = "UGA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "UKR", DisplayName = "Ukraine", DisplayCode = "UKR", Iso3Code = "UKR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "URU", DisplayName = "Uruguay", DisplayCode = "URU", Iso3Code = "URY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "USA", DisplayName = "United States", DisplayCode = "USA", Iso3Code = "USA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "UZB", DisplayName = "Uzbekistan", DisplayCode = "UZB", Iso3Code = "UZB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VAN", DisplayName = "Vanuatu", DisplayCode = "VAN", Iso3Code = "VUT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VEN", DisplayName = "Venezuela", DisplayCode = "VEN", Iso3Code = "VEN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VGB", DisplayName = "British Virgin Islands", DisplayCode = "VGB", Iso3Code = "VGB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VIE", DisplayName = "Vietnam", DisplayCode = "VIE", Iso3Code = "VNM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VIN", DisplayName = "Saint Vincent and the Grenadines", DisplayCode = "VIN", Iso3Code = "VCT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VIR", DisplayName = "United States Virgin Islands", DisplayCode = "VIR", Iso3Code = "VIR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "WAL", DisplayName = "Wales", DisplayCode = "WAL", Iso3Code = "WAL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "YEM", DisplayName = "Yemen", DisplayCode = "YEM", Iso3Code = "YEM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ZAM", DisplayName = "Zambia", DisplayCode = "ZAM", Iso3Code = "ZMB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ZIM", DisplayName = "Zimbabwe", DisplayCode = "ZIM", Iso3Code = "ZWE" });
            #endregion

            foreach (var pli in pliItems)
            {
                migrationBuilder.Sql($"IF NOT EXISTS (SELECT * FROM dbo.[ParticipantLibraryItem] WHERE [Name] = '{pli.Name}') BEGIN INSERT INTO[dbo].[ParticipantLibraryItem] ([NexusKey],[Name], [DisplayName], [DisplayCode], [Iso3Code], [TypeKey]) VALUES (NEWID(),'{pli.Name}','{pli.DisplayName}','{pli.DisplayCode}','{pli.Iso3Code}', (SELECT NexusKey FROM dbo.ParticipantLibraryItemType WHERE [Name] = 'COUNTRY')) END");
            };
        }
    }
}
