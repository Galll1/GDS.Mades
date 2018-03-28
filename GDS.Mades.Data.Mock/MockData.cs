namespace GDS.Mades.Data.Mock
{
    public class MockData
    {
        public string FirstString { get; set; } = Faker.TextFaker.Sentence();
        public string SecondString { get; set; } = Faker.TextFaker.Sentence();
        public int FirstInt { get; set; } = Faker.NumberFaker.Number();
        public int SecondInt { get; set; } = Faker.NumberFaker.Number();
        public float FirstFloat { get; set; } = Faker.NumberFaker.Number() / 1000f;
        public double FirstDouble { get; set; } = Faker.NumberFaker.Number() / 100d;
        public SubMockData FirstSubMockData { get; set; } = new SubMockData();
    }

    public class SubMockData
    {
        public string FirstSubString { get; set; } = Faker.StringFaker.AlphaNumeric(100);
        public string SecondSubString { get; set; } = Faker.StringFaker.AlphaNumeric(100);
        public int FirstSubInt { get; set; } = Faker.NumberFaker.Number();
        public int SecondSubInt { get; set; } = Faker.NumberFaker.Number();
        public float FirstSubFloat { get; set; } = Faker.NumberFaker.Number() / 1000f;
    }
}
