using System;
using System.Collections.Generic;
using Task3.Subjects;
using Task3.Vaccines;

namespace Task3
{
    class Program
    {
        public class MediaOutlet
        {
            public void Publish(IIterator iter)
            {
                // Console.WriteLine(...)
                while (iter.HasNext())
                    Console.WriteLine(iter.Next().ToString());               
            }
            
        }

        public class Tester
        {
            public void Test()
            {
                var vaccines = new List<IVaccine>() { new AvadaVaccine(), new Vaccinator3000(), new ReverseVaccine() };

                foreach (var vaccine in vaccines)
                {
                    Console.WriteLine($"Testing {vaccine}");
                    var subjects = new List<ISubject>();
                    int n = 5;
                    for (int i = 0; i < n; i++)
                    {
                        subjects.Add(new Cat($"{i}"));
                        subjects.Add(new Dog($"{i}"));
                        subjects.Add(new Pig($"{i}"));
                    }

                    foreach (var subject in subjects)
                    {
                        subject.GetVaccinated(vaccine);
                    }

                    var genomeDatabase = Generators.PrepareGenomes();
                    var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
                    // iteration over SimpleGenomeDatabase using solution from 1)
                    // subjects should be tested here using GetTested function


                    // iterating over simpleDatabase
                    SimpleDataRowIterator simpleIterator = new SimpleDataRowIterator(new SimpleDatabaseIterator(simpleDatabase), new SimpleGenomeDatabaseAdapter(genomeDatabase));
                    while(simpleIterator.HasNext())
                    {
                        VirusData vd = simpleIterator.Next();
                        foreach (var subject in subjects)
                        {
                            subject.GetTested(vd);
                        }
                    }

                    int aliveCount = 0;
                    foreach (var subject in subjects)
                    {
                        if (subject.Alive) aliveCount++;
                    }
                    Console.WriteLine($"{aliveCount} alive!");
                }
            }
        }
        public static void Main(string[] args)
        {
            var genomeDatabase = Generators.PrepareGenomes();
            var simpleDatabase = Generators.PrepareSimpleDatabase(genomeDatabase);
            var excellDatabase = Generators.PrepareExcellDatabase(genomeDatabase);
            var overcomplicatedDatabase = Generators.PrepareOvercomplicatedDatabase(genomeDatabase);
            
            var mediaOutlet = new MediaOutlet();
            Console.WriteLine("Simple Database");
            mediaOutlet.Publish(new SimpleDataRowIterator(new SimpleDatabaseIterator(simpleDatabase), new SimpleGenomeDatabaseAdapter(genomeDatabase)));
            Console.WriteLine();
            Console.WriteLine("Excell Database");
            mediaOutlet.Publish(new SimpleDataRowIterator(new ExcellDatabaseIterator(excellDatabase), new SimpleGenomeDatabaseAdapter(genomeDatabase)));
            Console.WriteLine();
            Console.WriteLine("Overcomplicated Database");
            mediaOutlet.Publish(new OvercomplicatedIterator(new OvercomplicatedDatabaseIterator(overcomplicatedDatabase), new SimpleGenomeDatabaseAdapter(genomeDatabase)));
            Console.WriteLine();
            Console.WriteLine("Filter more than 15");
            mediaOutlet.Publish(new FilterIterator(new SimpleDataRowIterator(new ExcellDatabaseIterator(excellDatabase), new SimpleGenomeDatabaseAdapter(genomeDatabase)), new FilterDeathRateMoreThan(15)));
            Console.WriteLine();
            Console.WriteLine("Filter less than 10");
            mediaOutlet.Publish(new FilterIterator(new SimpleDataRowIterator(new ExcellDatabaseIterator(excellDatabase), new SimpleGenomeDatabaseAdapter(genomeDatabase)), new FilterDeathRateLessThan(10)));
            Console.WriteLine();
            Console.WriteLine("Map death rate +1, filter more than 15");
            mediaOutlet.Publish(new FilterIterator(new MapperIterator(new SimpleDataRowIterator(new ExcellDatabaseIterator(excellDatabase), new SimpleGenomeDatabaseAdapter(genomeDatabase)), 
                new IncrementDeathRate(1)), new FilterDeathRateMoreThan(15)));
            Console.WriteLine();
            Console.WriteLine("Concatenated ExcellDatabase and OvercomplicatedDatabase");
            mediaOutlet.Publish(new ConcatenatedIterator(new SimpleDataRowIterator(new ExcellDatabaseIterator(excellDatabase), new SimpleGenomeDatabaseAdapter(genomeDatabase)), 
                new OvercomplicatedIterator(new OvercomplicatedDatabaseIterator(overcomplicatedDatabase), new SimpleGenomeDatabaseAdapter(genomeDatabase))));
            Console.WriteLine();

            // testing animals
            var tester = new Tester();
            tester.Test();
        }
    }
}
