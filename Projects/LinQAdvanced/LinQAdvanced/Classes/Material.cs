namespace LinQAdvanced.Classes
{
    public class Material : Entity
    {
        public string Name { get; set; }

        public Vendor Vendor { get; set; }

        public string VendorName { get; set; }

        public override int CompareTo(object obj)
        {
            Material materialObj = obj as Material;
            if (materialObj != null)
                return this.Name.CompareTo(materialObj.Name);
            else
                return this.ToString().CompareTo(obj.ToString());
        }

        public override bool Equals(Entity other)
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
