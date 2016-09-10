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
            pliItems.Add(new ParticipantLibraryItem { Name = "AFG", Iso2Code="AF", DisplayName = "Afghanistan", DisplayCode = "AFG", Iso3Code = "AFG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AIA", Iso2Code="AI", DisplayName = "Anguilla", DisplayCode = "AIA", Iso3Code = "AIA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ALB", Iso2Code="AL", DisplayName = "Albania", DisplayCode = "ALB", Iso3Code = "ALB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ALG", Iso2Code="DZ", DisplayName = "Algeria", DisplayCode = "ALG", Iso3Code = "DZA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AND", Iso2Code="AD", DisplayName = "Andorra", DisplayCode = "AND", Iso3Code = "AND" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ANG", Iso2Code="AO", DisplayName = "Angola", DisplayCode = "ANG", Iso3Code = "AGO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ARG", Iso2Code="AR", DisplayName = "Argentina", DisplayCode = "ARG", Iso3Code = "ARG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ARM", Iso2Code="AM", DisplayName = "Armenia", DisplayCode = "ARM", Iso3Code = "ARM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ARU", Iso2Code="AW", DisplayName = "Aruba", DisplayCode = "ARU", Iso3Code = "ABW" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ASA", Iso2Code="AS", DisplayName = "American Samoa", DisplayCode = "ASA", Iso3Code = "ASM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ATG", Iso2Code="AG", DisplayName = "Antigua and Barbuda", DisplayCode = "ATG", Iso3Code = "ATG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AUS", Iso2Code="AU", DisplayName = "Australia", DisplayCode = "AUS", Iso3Code = "AUS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AUT", Iso2Code="AT", DisplayName = "Austria", DisplayCode = "AUT", Iso3Code = "AUT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "AZE", Iso2Code="AZ", DisplayName = "Azerbaijan", DisplayCode = "AZE", Iso3Code = "AZE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BAH", Iso2Code="BS", DisplayName = "Bahamas", DisplayCode = "BAH", Iso3Code = "BHS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BAN", Iso2Code="BD", DisplayName = "Bangladesh", DisplayCode = "BAN", Iso3Code = "BGD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BDI", Iso2Code="BI", DisplayName = "Burundi", DisplayCode = "BDI", Iso3Code = "BDI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BEL", Iso2Code="BE", DisplayName = "Belgium", DisplayCode = "BEL", Iso3Code = "BEL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BEN", Iso2Code="BJ", DisplayName = "Benin", DisplayCode = "BEN", Iso3Code = "BEN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BER", Iso2Code="BM", DisplayName = "Bermuda", DisplayCode = "BER", Iso3Code = "BMU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BFA", Iso2Code="BF", DisplayName = "Burkina Faso", DisplayCode = "BFA", Iso3Code = "BFA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BHR", Iso2Code="BH", DisplayName = "Bahrain", DisplayCode = "BHR", Iso3Code = "BHR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BHU", Iso2Code="BT", DisplayName = "Bhutan", DisplayCode = "BHU", Iso3Code = "BTN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BIH", Iso2Code="BA", DisplayName = "Bosnia and Herzegovina", DisplayCode = "BIH", Iso3Code = "BIH" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BLR", Iso2Code="BY", DisplayName = "Belarus", DisplayCode = "BLR", Iso3Code = "BLR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BLZ", Iso2Code="BZ", DisplayName = "Belize", DisplayCode = "BLZ", Iso3Code = "BLZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BOL", Iso2Code="BO", DisplayName = "Bolivia", DisplayCode = "BOL", Iso3Code = "BOL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BOT", Iso2Code="BW", DisplayName = "Botswana", DisplayCode = "BOT", Iso3Code = "BWA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BRA", Iso2Code="BR", DisplayName = "Brazil", DisplayCode = "BRA", Iso3Code = "BRA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BRB", Iso2Code="BB", DisplayName = "Barbados", DisplayCode = "BRB", Iso3Code = "BRB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BRU", Iso2Code="BN", DisplayName = "Brunei", DisplayCode = "BRU", Iso3Code = "BRN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "BUL", Iso2Code="BG", DisplayName = "Bulgaria", DisplayCode = "BUL", Iso3Code = "BGR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CAM", Iso2Code="KH", DisplayName = "Cambodia", DisplayCode = "CAM", Iso3Code = "KHM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CAN", Iso2Code="CA", DisplayName = "Canada", DisplayCode = "CAN", Iso3Code = "CAN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CAY", Iso2Code="KY", DisplayName = "Cayman Islands", DisplayCode = "CAY", Iso3Code = "CYM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CGO", Iso2Code="CD", DisplayName = "Congo", DisplayCode = "CGO", Iso3Code = "COG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CHA", Iso2Code="TD", DisplayName = "Chad", DisplayCode = "CHA", Iso3Code = "TCD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CHI", Iso2Code="CL", DisplayName = "Chile", DisplayCode = "CHI", Iso3Code = "CHL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CHN", Iso2Code="CN", DisplayName = "China", DisplayCode = "CHN", Iso3Code = "CHN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CIV", Iso2Code="CI", DisplayName = "Côte d''Ivoire", DisplayCode = "CIV", Iso3Code = "CIV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CMR", Iso2Code="CM", DisplayName = "Cameroon", DisplayCode = "CMR", Iso3Code = "CMR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "COK", Iso2Code="Ck", DisplayName = "Cook Islands", DisplayCode = "COK", Iso3Code = "COK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "COL", Iso2Code="CO", DisplayName = "Colombia", DisplayCode = "COL", Iso3Code = "COL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "COM", Iso2Code="KM", DisplayName = "Comoros", DisplayCode = "COM", Iso3Code = "COM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CPV", Iso2Code="CV", DisplayName = "Cape Verde", DisplayCode = "CPV", Iso3Code = "CPV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CRC", Iso2Code="CR", DisplayName = "Costa Rica", DisplayCode = "CRC", Iso3Code = "CRI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CRO", Iso2Code="HR", DisplayName = "Croatia", DisplayCode = "CRO", Iso3Code = "HRV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CTA", Iso2Code="CF", DisplayName = "Central African Republic", DisplayCode = "CTA", Iso3Code = "CAF" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CUB", Iso2Code="CU", DisplayName = "Cuba", DisplayCode = "CUB", Iso3Code = "CUB" });
            //pliItems.Add(new ParticipantLibraryItem { Name = "CUW", Iso2Code="CY", DisplayName = "Curaçao", DisplayCode = "CUW", Iso3Code = "CUW" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CYP", Iso2Code="CY", DisplayName = "Cyprus", DisplayCode = "CYP", Iso3Code = "CYP" });
            pliItems.Add(new ParticipantLibraryItem { Name = "CZE", Iso2Code="CZ", DisplayName = "Czech Republic", DisplayCode = "CZE", Iso3Code = "CZE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "DEN", Iso2Code="DK", DisplayName = "Denmark", DisplayCode = "DEN", Iso3Code = "DNK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "DJI", Iso2Code="DJ", DisplayName = "Djibouti", DisplayCode = "DJI", Iso3Code = "DJI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "DMA", Iso2Code="DM", DisplayName = "Dominica", DisplayCode = "DMA", Iso3Code = "DMA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "DOM", Iso2Code="DO", DisplayName = "Dominican Republic", DisplayCode = "DOM", Iso3Code = "DOM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ECU", Iso2Code="EC", DisplayName = "Ecuador", DisplayCode = "ECU", Iso3Code = "ECU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "EGY", Iso2Code="EG", DisplayName = "Egypt", DisplayCode = "EGY", Iso3Code = "EGY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ENG", Iso2Code="ENGLAND", DisplayName = "England", DisplayCode = "ENG", Iso3Code = "ENG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "EQG", Iso2Code="GQ", DisplayName = "Equatorial Guinea", DisplayCode = "EQG", Iso3Code = "GNQ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ERI", Iso2Code="ER", DisplayName = "Eritrea", DisplayCode = "ERI", Iso3Code = "ERI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ESP", Iso2Code="ES", DisplayName = "Spain", DisplayCode = "ESP", Iso3Code = "ESP" });
            pliItems.Add(new ParticipantLibraryItem { Name = "EST", Iso2Code="EE", DisplayName = "Estonia", DisplayCode = "EST", Iso3Code = "EST" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ETH", Iso2Code="ET", DisplayName = "Ethiopia", DisplayCode = "ETH", Iso3Code = "ETH" });
            pliItems.Add(new ParticipantLibraryItem { Name = "FIJ", Iso2Code="FJ", DisplayName = "Fiji", DisplayCode = "FIJ", Iso3Code = "FJI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "FIN", Iso2Code="FI", DisplayName = "Finland", DisplayCode = "FIN", Iso3Code = "FIN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "FRA", Iso2Code="FR", DisplayName = "France", DisplayCode = "FRA", Iso3Code = "FRA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "FRO", Iso2Code="FO", DisplayName = "Faroe Islands", DisplayCode = "FRO", Iso3Code = "FRO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GAB", Iso2Code="GA", DisplayName = "Gabon", DisplayCode = "GAB", Iso3Code = "GAB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GAM", Iso2Code="GM", DisplayName = "Gambia", DisplayCode = "GAM", Iso3Code = "GMB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GBR", Iso2Code="GB", DisplayName = "United Kingdom", DisplayCode = "GBR", Iso3Code = "GBR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GEO", Iso2Code="GE", DisplayName = "Georgia", DisplayCode = "GEO", Iso3Code = "GEO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GER", Iso2Code="DE", DisplayName = "Germany", DisplayCode = "GER", Iso3Code = "DEU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GHA", Iso2Code="GH", DisplayName = "Ghana", DisplayCode = "GHA", Iso3Code = "GHA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GIB", Iso2Code="GI", DisplayName = "Gibraltar", DisplayCode = "GIB", Iso3Code = "GIB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GNB", Iso2Code="GW", DisplayName = "Guinea-Bissau", DisplayCode = "GNB", Iso3Code = "GNB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GRE", Iso2Code="GR", DisplayName = "Greece", DisplayCode = "GRE", Iso3Code = "GRC" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GRN", Iso2Code="GD", DisplayName = "Grenada", DisplayCode = "GRN", Iso3Code = "GRD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GUA", Iso2Code="GT", DisplayName = "Guatemala", DisplayCode = "GUA", Iso3Code = "GTM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GUI", Iso2Code="GN", DisplayName = "Guinea", DisplayCode = "GUI", Iso3Code = "GIN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GUM", Iso2Code="GU", DisplayName = "Guam", DisplayCode = "GUM", Iso3Code = "GUM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "GUY", Iso2Code="GY", DisplayName = "Guyana", DisplayCode = "GUY", Iso3Code = "GUY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "HAI", Iso2Code="HT", DisplayName = "Haiti", DisplayCode = "HAI", Iso3Code = "HTI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "HKG", Iso2Code="HK", DisplayName = "Hong Kong", DisplayCode = "HKG", Iso3Code = "HKG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "HON", Iso2Code="HN", DisplayName = "Honduras", DisplayCode = "HON", Iso3Code = "HND" });
            pliItems.Add(new ParticipantLibraryItem { Name = "HUN", Iso2Code="HU", DisplayName = "Hungary", DisplayCode = "HUN", Iso3Code = "HUN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IDN", Iso2Code="ID", DisplayName = "Indonesia", DisplayCode = "IDN", Iso3Code = "IDN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IND", Iso2Code="IN", DisplayName = "India", DisplayCode = "IND", Iso3Code = "IND" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IRL", Iso2Code="IE", DisplayName = "Ireland", DisplayCode = "IRL", Iso3Code = "IRL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IRN", Iso2Code="IR", DisplayName = "Iran", DisplayCode = "IRN", Iso3Code = "IRN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "IRQ", Iso2Code="IQ", DisplayName = "Iraq", DisplayCode = "IRQ", Iso3Code = "IRQ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ISL", Iso2Code="IS", DisplayName = "Iceland", DisplayCode = "ISL", Iso3Code = "ISL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ISR", Iso2Code="IL", DisplayName = "Israel", DisplayCode = "ISR", Iso3Code = "ISR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ITA", Iso2Code="IT", DisplayName = "Italy", DisplayCode = "ITA", Iso3Code = "ITA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "JAM", Iso2Code="JM", DisplayName = "Jamaica", DisplayCode = "JAM", Iso3Code = "JAM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "JOR", Iso2Code="JO", DisplayName = "Jordan", DisplayCode = "JOR", Iso3Code = "JOR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "JPN", Iso2Code="JP", DisplayName = "Japan", DisplayCode = "JPN", Iso3Code = "JPN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KAZ", Iso2Code="KZ", DisplayName = "Kazakhstan", DisplayCode = "KAZ", Iso3Code = "KAZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KEN", Iso2Code="KE", DisplayName = "Kenya", DisplayCode = "KEN", Iso3Code = "KEN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KGZ", Iso2Code="KG", DisplayName = "Kyrgyzstan", DisplayCode = "KGZ", Iso3Code = "KGZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KOR", Iso2Code="KR", DisplayName = "South Korea", DisplayCode = "KOR", Iso3Code = "KOR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KSA", Iso2Code="SA", DisplayName = "Saudi Arabia", DisplayCode = "KSA", Iso3Code = "SAU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KUW", Iso2Code="KW", DisplayName = "Kuwait", DisplayCode = "KUW", Iso3Code = "KWT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "KVX", Iso2Code="KO", DisplayName = "Kosovo", DisplayCode = "KVX", Iso3Code = "KOS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LAO", Iso2Code="LA", DisplayName = "Laos", DisplayCode = "LAO", Iso3Code = "LAO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LBR", Iso2Code="LR", DisplayName = "Liberia", DisplayCode = "LBR", Iso3Code = "LBR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LBY", Iso2Code="LY", DisplayName = "Libya", DisplayCode = "LBY", Iso3Code = "LBY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LCA", Iso2Code="LC", DisplayName = "Saint Lucia", DisplayCode = "LCA", Iso3Code = "LCA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LES", Iso2Code="LS", DisplayName = "Lesotho", DisplayCode = "LES", Iso3Code = "LSO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LIB", Iso2Code="LB", DisplayName = "Lebanon", DisplayCode = "LIB", Iso3Code = "LBN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LIE", Iso2Code="LI", DisplayName = "Liechtenstein", DisplayCode = "LIE", Iso3Code = "LIE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LTU", Iso2Code="LT", DisplayName = "Lithuania", DisplayCode = "LTU", Iso3Code = "LTU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LUX", Iso2Code="LU", DisplayName = "Luxembourg", DisplayCode = "LUX", Iso3Code = "LUX" });
            pliItems.Add(new ParticipantLibraryItem { Name = "LVA", Iso2Code="LV", DisplayName = "Latvia", DisplayCode = "LVA", Iso3Code = "LVA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MAC", Iso2Code="MO", DisplayName = "Macau", DisplayCode = "MAC", Iso3Code = "MAC" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MAD", Iso2Code="MG", DisplayName = "Madagascar", DisplayCode = "MAD", Iso3Code = "MDG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MAR", Iso2Code="MA", DisplayName = "Morocco", DisplayCode = "MAR", Iso3Code = "MAR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MAS", Iso2Code="MY", DisplayName = "Malaysia", DisplayCode = "MAS", Iso3Code = "MYS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MDA", Iso2Code="MD", DisplayName = "Moldova", DisplayCode = "MDA", Iso3Code = "MDA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MDV", Iso2Code="MV", DisplayName = "Maldives", DisplayCode = "MDV", Iso3Code = "MDV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MEX", Iso2Code="MX", DisplayName = "Mexico", DisplayCode = "MEX", Iso3Code = "MEX" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MGL", Iso2Code="MN", DisplayName = "Mongolia", DisplayCode = "MGL", Iso3Code = "MNG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MKD", Iso2Code="MK", DisplayName = "Macedonia", DisplayCode = "MKD", Iso3Code = "MKD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MLI", Iso2Code="ML", DisplayName = "Mali", DisplayCode = "MLI", Iso3Code = "MLI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MLT", Iso2Code="MT", DisplayName = "Malta", DisplayCode = "MLT", Iso3Code = "MLT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MNE", Iso2Code="ME", DisplayName = "Montenegro", DisplayCode = "MNE", Iso3Code = "MNE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MOZ", Iso2Code="MZ", DisplayName = "Mozambique", DisplayCode = "MOZ", Iso3Code = "MOZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MRI", Iso2Code="MU", DisplayName = "Mauritius", DisplayCode = "MRI", Iso3Code = "MUS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MSR", Iso2Code="MS", DisplayName = "Montserrat", DisplayCode = "MSR", Iso3Code = "MSR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MTN", Iso2Code="MR", DisplayName = "Mauritania", DisplayCode = "MTN", Iso3Code = "MRT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MWI", Iso2Code="MW", DisplayName = "Malawi", DisplayCode = "MWI", Iso3Code = "MWI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "MYA", Iso2Code="MM", DisplayName = "Myanmar", DisplayCode = "MYA", Iso3Code = "MMR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NAM", Iso2Code="NA", DisplayName = "Namibia", DisplayCode = "NAM", Iso3Code = "NAM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NCA", Iso2Code="NI", DisplayName = "Nicaragua", DisplayCode = "NCA", Iso3Code = "NIC" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NCL", Iso2Code="NC", DisplayName = "New Caledonia", DisplayCode = "NCL", Iso3Code = "NCL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NED", Iso2Code="NL", DisplayName = "Netherlands", DisplayCode = "NED", Iso3Code = "NLD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NEP", Iso2Code="NP", DisplayName = "Nepal", DisplayCode = "NEP", Iso3Code = "NPL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NGA", Iso2Code="NG", DisplayName = "Nigeria", DisplayCode = "NGA", Iso3Code = "NGA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NIG", Iso2Code="NE", DisplayName = "Niger", DisplayCode = "NIG", Iso3Code = "NER" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NIR", Iso2Code="NORTHRN_IRELAND", DisplayName = "Northern Ireland", DisplayCode = "NIR", Iso3Code = "NIR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NOR", Iso2Code="NO", DisplayName = "Norway", DisplayCode = "NOR", Iso3Code = "NOR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "NZL", Iso2Code="NZ", DisplayName = "New Zealand", DisplayCode = "NZL", Iso3Code = "NZL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "OMA", Iso2Code="OM", DisplayName = "Oman", DisplayCode = "OMA", Iso3Code = "OMN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PAK", Iso2Code="PK", DisplayName = "Pakistan", DisplayCode = "PAK", Iso3Code = "PAK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PAN", Iso2Code="PA", DisplayName = "Panama", DisplayCode = "PAN", Iso3Code = "PAN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PAR", Iso2Code="PY", DisplayName = "Paraguay", DisplayCode = "PAR", Iso3Code = "PRY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PER", Iso2Code="PE", DisplayName = "Peru", DisplayCode = "PER", Iso3Code = "PER" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PHI", Iso2Code="PH", DisplayName = "Philippines", DisplayCode = "PHI", Iso3Code = "PHL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PLE", Iso2Code="PS", DisplayName = "State of Palestine", DisplayCode = "PLE", Iso3Code = "PSE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PNG", Iso2Code="PG", DisplayName = "Papua New Guinea", DisplayCode = "PNG", Iso3Code = "PNG" });
            pliItems.Add(new ParticipantLibraryItem { Name = "POL", Iso2Code="PL", DisplayName = "Poland", DisplayCode = "POL", Iso3Code = "POL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "POR", Iso2Code="PT", DisplayName = "Portugal", DisplayCode = "POR", Iso3Code = "PRT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PRK", Iso2Code="KP", DisplayName = "North Korea", DisplayCode = "PRK", Iso3Code = "PRK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "PUR", Iso2Code="PR", DisplayName = "Puerto Rico", DisplayCode = "PUR", Iso3Code = "PRI" });
            pliItems.Add(new ParticipantLibraryItem { Name = "QAT", Iso2Code="QA", DisplayName = "Qatar", DisplayCode = "QAT", Iso3Code = "QAT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ROU", Iso2Code="RO", DisplayName = "Romania", DisplayCode = "ROU", Iso3Code = "ROU" });
            pliItems.Add(new ParticipantLibraryItem { Name = "RSA", Iso2Code="ZA", DisplayName = "South Africa", DisplayCode = "RSA", Iso3Code = "ZAF" });
            pliItems.Add(new ParticipantLibraryItem { Name = "RUS", Iso2Code="RU", DisplayName = "Russian Federation", DisplayCode = "RUS", Iso3Code = "RUS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "RWA", Iso2Code="RW", DisplayName = "Rwanda", DisplayCode = "RWA", Iso3Code = "RWA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SAM", Iso2Code="WS", DisplayName = "Samoa", DisplayCode = "SAM", Iso3Code = "WSM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SCO", Iso2Code="SCOTLAND", DisplayName = "Scotland", DisplayCode = "SCO", Iso3Code = "SCO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SDN", Iso2Code="SD", DisplayName = "Sudan", DisplayCode = "SDN", Iso3Code = "SDN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SEN", Iso2Code="SN", DisplayName = "Senegal", DisplayCode = "SEN", Iso3Code = "SEN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SEY", Iso2Code="SC", DisplayName = "Seychelles", DisplayCode = "SEY", Iso3Code = "SYC" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SIN", Iso2Code="SG", DisplayName = "Singapore", DisplayCode = "SIN", Iso3Code = "SGP" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SKN", Iso2Code="KN", DisplayName = "Saint Kitts and Nevis", DisplayCode = "SKN", Iso3Code = "KNA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SLE", Iso2Code="SL", DisplayName = "Sierra Leone", DisplayCode = "SLE", Iso3Code = "SLE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SLV", Iso2Code="SV", DisplayName = "El Salvador", DisplayCode = "SLV", Iso3Code = "SLV" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SMR", Iso2Code="SM", DisplayName = "San Marino", DisplayCode = "SMR", Iso3Code = "SMR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SOL", Iso2Code="SB", DisplayName = "Solomon Islands", DisplayCode = "SOL", Iso3Code = "SLB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SOM", Iso2Code="SO", DisplayName = "Somalia", DisplayCode = "SOM", Iso3Code = "SOM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SRB", Iso2Code="RS", DisplayName = "Serbia", DisplayCode = "SRB", Iso3Code = "SRB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SRI", Iso2Code="LK", DisplayName = "Sri Lanka", DisplayCode = "SRI", Iso3Code = "LKA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SSD", Iso2Code="SS", DisplayName = "South Sudan", DisplayCode = "SSD", Iso3Code = "SSD" });
            pliItems.Add(new ParticipantLibraryItem { Name = "STP", Iso2Code="ST", DisplayName = "São Tomé and Príncipe", DisplayCode = "STP", Iso3Code = "STP" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SUI", Iso2Code="CH", DisplayName = "Switzerland", DisplayCode = "SUI", Iso3Code = "CHE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SUR", Iso2Code="SR", DisplayName = "Suriname", DisplayCode = "SUR", Iso3Code = "SUR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SVK", Iso2Code="SK", DisplayName = "Slovakia", DisplayCode = "SVK", Iso3Code = "SVK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SVN", Iso2Code="SI", DisplayName = "Slovenia", DisplayCode = "SVN", Iso3Code = "SVN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SWE", Iso2Code="SE", DisplayName = "Sweden", DisplayCode = "SWE", Iso3Code = "SWE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SWZ", Iso2Code="SZ", DisplayName = "Swaziland", DisplayCode = "SWZ", Iso3Code = "SWZ" });
            pliItems.Add(new ParticipantLibraryItem { Name = "SYR", Iso2Code="SY", DisplayName = "Syria", DisplayCode = "SYR", Iso3Code = "SYR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TAH", Iso2Code="PF", DisplayName = "French Polynesia", DisplayCode = "TAH", Iso3Code = "PYF" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TAN", Iso2Code="TZ", DisplayName = "Tanzania", DisplayCode = "TAN", Iso3Code = "TZA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TCA", Iso2Code="TC", DisplayName = "Turks and Caicos Islands", DisplayCode = "TCA", Iso3Code = "TCA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TGA", Iso2Code="TO", DisplayName = "Tonga", DisplayCode = "TGA", Iso3Code = "TON" });
            pliItems.Add(new ParticipantLibraryItem { Name = "THA", Iso2Code="TH", DisplayName = "Thailand", DisplayCode = "THA", Iso3Code = "THA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TJK", Iso2Code="TJ", DisplayName = "Tajikistan", DisplayCode = "TJK", Iso3Code = "TJK" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TKM", Iso2Code="TM", DisplayName = "Turkmenistan", DisplayCode = "TKM", Iso3Code = "TKM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TLS", Iso2Code="TL", DisplayName = "Timor-Leste", DisplayCode = "TLS", Iso3Code = "TLS" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TOG", Iso2Code="TG", DisplayName = "Togo", DisplayCode = "TOG", Iso3Code = "TGO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TPE", Iso2Code="TW", DisplayName = "Taiwan", DisplayCode = "TPE", Iso3Code = "TWN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TRI", Iso2Code="TT", DisplayName = "Trinidad and Tobago", DisplayCode = "TRI", Iso3Code = "TTO" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TUN", Iso2Code="TN", DisplayName = "Tunisia", DisplayCode = "TUN", Iso3Code = "TUN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "TUR", Iso2Code="TR", DisplayName = "Turkey", DisplayCode = "TUR", Iso3Code = "TUR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "UAE", Iso2Code="AE", DisplayName = "United Arab Emirates", DisplayCode = "UAE", Iso3Code = "ARE" });
            pliItems.Add(new ParticipantLibraryItem { Name = "UGA", Iso2Code="UG", DisplayName = "Uganda", DisplayCode = "UGA", Iso3Code = "UGA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "UKR", Iso2Code="UA", DisplayName = "Ukraine", DisplayCode = "UKR", Iso3Code = "UKR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "URU", Iso2Code="UY", DisplayName = "Uruguay", DisplayCode = "URU", Iso3Code = "URY" });
            pliItems.Add(new ParticipantLibraryItem { Name = "USA", Iso2Code="US", DisplayName = "United States", DisplayCode = "USA", Iso3Code = "USA" });
            pliItems.Add(new ParticipantLibraryItem { Name = "UZB", Iso2Code="UZ", DisplayName = "Uzbekistan", DisplayCode = "UZB", Iso3Code = "UZB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VAN", Iso2Code="VU", DisplayName = "Vanuatu", DisplayCode = "VAN", Iso3Code = "VUT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VEN", Iso2Code="VE", DisplayName = "Venezuela", DisplayCode = "VEN", Iso3Code = "VEN" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VGB", Iso2Code="VG", DisplayName = "British Virgin Islands", DisplayCode = "VGB", Iso3Code = "VGB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VIE", Iso2Code="VN", DisplayName = "Vietnam", DisplayCode = "VIE", Iso3Code = "VNM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VIN", Iso2Code="VC", DisplayName = "Saint Vincent and the Grenadines", DisplayCode = "VIN", Iso3Code = "VCT" });
            pliItems.Add(new ParticipantLibraryItem { Name = "VIR", Iso2Code="VI", DisplayName = "United States Virgin Islands", DisplayCode = "VIR", Iso3Code = "VIR" });
            pliItems.Add(new ParticipantLibraryItem { Name = "WAL", Iso2Code="WALES", DisplayName = "Wales", DisplayCode = "WAL", Iso3Code = "WAL" });
            pliItems.Add(new ParticipantLibraryItem { Name = "YEM", Iso2Code="YE", DisplayName = "Yemen", DisplayCode = "YEM", Iso3Code = "YEM" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ZAM", Iso2Code="ZM", DisplayName = "Zambia", DisplayCode = "ZAM", Iso3Code = "ZMB" });
            pliItems.Add(new ParticipantLibraryItem { Name = "ZIM", Iso2Code="ZW", DisplayName = "Zimbabwe", DisplayCode = "ZIM", Iso3Code = "ZWE" });
            #endregion

            foreach (var pli in pliItems)
            {
                migrationBuilder.Sql($"IF NOT EXISTS (SELECT * FROM dbo.[ParticipantLibraryItem] WHERE [Name] = '{pli.Name}') BEGIN INSERT INTO[dbo].[ParticipantLibraryItem] ([NexusKey],[Name], [DisplayName], [DisplayCode], [Iso2Code], [Iso3Code], [TypeKey]) VALUES (NEWID(),'{pli.Name}','{pli.DisplayName}','{pli.DisplayCode}','{pli.Iso2Code}','{pli.Iso3Code}', (SELECT NexusKey FROM dbo.ParticipantLibraryItemType WHERE [Name] = 'COUNTRY')) END");
            };
        }
    }
}
