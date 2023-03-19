namespace MnemonicPdf.Models
{
    public class PageFormat
    {
        public string Name { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public string Unit { get; set; }

        public string FormatWidth => $"{Width}{Unit}";

        public string FormatHeight => $"{Height}{Unit}";

        public override string ToString()
        {
            return Name;
        }
    }
}
