using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestPointSearchEngine
{
    public class InterestPointRepo
    {
        private List<InterestPoint> _interestPoints;       

        public InterestPointRepo()
        {
            _interestPoints = new List<InterestPoint>();    
        }

        public List<InterestPoint> InterestPoints { get { return _interestPoints; } }

        public void Add(string type, string name, string description)
        {
            _interestPoints.Add(new InterestPoint(name,type,description));   
        }
    }
}
