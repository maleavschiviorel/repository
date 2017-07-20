namespace LinQAdvanced.Classes
{
    public class Vendor : Entity
    {
        public string Name { get; set; }

        public override int CompareTo(object obj)
        {
            Vendor vendorObj = obj as Vendor;
            if (vendorObj != null)
                return this.Name.CompareTo(vendorObj.Name);
            else
                return this.ToString().CompareTo(obj.ToString());
        }

        public override bool Equals(Entity other)
        {
            Vendor vendorObj = other as Vendor;
            if (vendorObj != null)
                return this.Name.Equals(vendorObj.Name);
            else
                return this.ToString().Equals(other.ToString());
        }

        public override string ToString()
        {
            return "Vendor {Name='"+Name+"'}";
        }
    }
}
