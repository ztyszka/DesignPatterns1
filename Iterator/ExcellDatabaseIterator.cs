using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Task3
{
    class ExcellDatabaseIterator : IDatabaseIterator
    {
        private ExcellDatabase database;
        private int namePosition;
        private int deathRatePosition;
        private int infectionRatePosition;
        private int genomeIdPosition;
        public ExcellDatabaseIterator(ExcellDatabase database)
        {
            this.database = database;
            this.namePosition = 0;
            this.deathRatePosition = 0;
            this.infectionRatePosition = 0;
            this.genomeIdPosition = 0;
        }
        public bool HasNext()
        {
            if (namePosition < database.Names.Length && deathRatePosition < database.DeathRates.Length
                && infectionRatePosition < database.InfectionRates.Length && genomeIdPosition < database.GenomeIds.Length)
                return true;
            return false;
        }

        public SimpleDatabaseRow Next()
        {
            string name = ReadDataRow(database.Names, ref namePosition, database.Names.Length);
            double deathRate;
            double.TryParse(ReadDataRow(database.DeathRates, ref deathRatePosition, database.DeathRates.Length), NumberStyles.Number, CultureInfo.InvariantCulture, out deathRate);
            double infectionRate;
            double.TryParse(ReadDataRow(database.InfectionRates, ref infectionRatePosition, database.InfectionRates.Length), NumberStyles.Number, CultureInfo.InvariantCulture, out infectionRate);
            Guid genomeId = Guid.Parse(ReadDataRow(database.GenomeIds, ref genomeIdPosition, database.GenomeIds.Length));
            SimpleDatabaseRow sdr = new SimpleDatabaseRow();
            sdr.VirusName = name;
            sdr.DeathRate = deathRate;
            sdr.InfectionRate = infectionRate;
            sdr.GenomeId = genomeId;
            return sdr;
        }

        private string ReadDataRow(string dataRow, ref int position, int limit)
        {
            int p = position;
            StringBuilder sb = new StringBuilder();
            while(p < limit && dataRow[p] != ';')
            {
                sb.Append(dataRow[p]);
                p++;
            }
            p++;
            position = p;
            return sb.ToString();
        }
    }
}
