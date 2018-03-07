using GraphUtil;
using PersonRelations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonRelations
{
    public class PersonRelationUtil
    {
        private Graph<Person> _graph = null;
        private Action<string> _logger = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">optional logging method</param>
        public PersonRelationUtil(Action<string> logger = null)
        {
            _logger = logger;
        }

        public void Init(Person[] persons)
        {
            //build graph
            _graph = new Graph<Person>(persons, BuildEdges(persons),_logger);
        }

        /// <summary>
        /// Build edges to given vertices according to predifined logic
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        private IEnumerable<Tuple<Person, Person>> BuildEdges(IEnumerable<Person> persons)
        {
            var refGroup = persons.ToArray(); // copy the group to ref group 

            List<Tuple<Person, Person>> res = new List<Tuple<Person, Person>>();

            foreach (var item1 in refGroup)
            {
                foreach (var item2 in persons)
                {
                    if (object.ReferenceEquals(item1, item2)) continue;

                    if (item1.DirectlyRelated(item2))
                    {
                        res.Add(new Tuple<Person, Person>(item1, item2));
                    }
                }
            }

            return res;
        }



        /// <summary>
        /// Retruns the found path from A to B
        /// </summary>
        /// <param name="personA"></param>
        /// <param name="personB"></param>
        /// <returns></returns>
        public Person[] FindMinRelationLevelPath(Person personA, Person personB)
        {
            Algorithms algorithms = new Algorithms(_logger);
            //define the match criteria between two persons
            Func<Person,Person,bool> matchCriteria = (p1, p2) => object.ReferenceEquals(p1, p2);
            return algorithms.BFS<Person>(_graph, personA, personB,matchCriteria);
        }

        /// <summary>
        /// Returns the shortes hop count from personA to personB
        /// </summary>
        /// <param name="personA"></param>
        /// <param name="personB"></param>
        /// <returns></returns>
        public int FindMinRelationLevel(Person personA, Person personB)
        {
            var path = FindMinRelationLevelPath(personA, personB);
            if (path != null)
                return path.Length - 1;
            //no path
            return -1;
        }
    }
}
