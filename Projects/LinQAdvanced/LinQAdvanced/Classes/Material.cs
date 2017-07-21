namespace LinQAdvanced.Classes
{
    public class Material : Entity
    {
        public Vendor Vendor { get; set; }

        public string VendorName { get; set; }

        public  int CompareTo(Entity obj)
        {
            return MyCompareTo(obj);
        }

        public  bool Equals(Entity other)
        {
            return MyEquals(other);
        }
        public override int MyCompareTo(Entity  obj)
        {
            Material materialObj = obj as Material;
            if (materialObj != null)
                return this.Name.CompareTo(materialObj.Name);
            else
                return this.ToString().CompareTo(obj.ToString());
        }

        public override bool MyEquals(Entity other)
        {
            Material materialObj = other as Material;
            if (materialObj != null)
                return this.Name.Equals(materialObj.Name);
            else
                return this.ToString().Equals(other.ToString());
        }
        public override string ToString()
        {
            return "Material {Name='"+Name+ "', {" + Vendor.ToString()+"}}"  ;
        }
    }
}
