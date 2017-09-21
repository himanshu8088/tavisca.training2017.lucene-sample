namespace InterestPointSearchEngine
{
    public class InterestPoint
    {
        private string _name;
        private string _type;
        private string _description;

        public InterestPoint(string name, string type, string description)
        {
            this._name = name;
            this._type = type;
            this._description = description;
        }

        public string Name { get { return _name; } }
        public string Type { get { return _type; } }
        public string Description { get { return _description; } }

        public override string ToString()
        {
            return $"{this.Name} is {this.Type}({this.Description})";
        }
    }
}