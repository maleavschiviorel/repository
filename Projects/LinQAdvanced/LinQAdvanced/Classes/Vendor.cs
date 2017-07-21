namespace LinQAdvanced.Classes
{
    public class Vendor : Entity
    {
        public string Name { get; set; }

        public  int CompareTo(Entity  obj)
        {
            return MyCompareTo(obj);
        }

        public  bool Equals(Entity other)
        {
            return MyEquals(other);
        }

        public override int MyCompareTo(Entity obj)
        {
            Vendor vendorObj = obj as Vendor;
            if (vendorObj != null)
                return this.Name.CompareTo(vendorObj.Name);
            else
                return this.ToString().CompareTo(obj.ToString());
        }

        public override bool MyEquals(Entity other)
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
