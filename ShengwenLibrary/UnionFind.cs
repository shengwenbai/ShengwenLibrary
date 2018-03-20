

namespace ShengwenLibrary
{
    // Inspired by Princeton Algorithms course(http://algs4.cs.princeton.edu) 
    public class UnionFind
    {
        /*
         _count: Total number of unions(including single members)
         _id[i]: The parent of i
         _sz[i]: Total # of objs in the tree rooted at i
         */
        private int _count;
        private readonly int[] _id;
        private readonly int[] _sz;

        public UnionFind(int total)
        {
            _count = total;
            _id = new int[total];
            _sz = new int[total];
            for (var i = 0; i < total; i++)
            {
                _id[i] = i;
            }
        }

        private int Root(int i)
        {
            while (_id[i] != i)
            {
                i = _id[i];
                _id[i] = _id[_id[i]];
            }
            return i;
        }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        // linking root of smaller tree to root of larger tree
        public void Union(int p, int q)
        {
            var i = Root(p);
            var j = Root(q);
            if (i == j) return;
            if (_sz[i] < _sz[j])
            {
                _id[i] = j;
                _sz[j] += _sz[i];
            }
            else
            {
                _id[j] = i;
                _sz[i] += _sz[j];
            }
            _count--;

        }
        public int CountUnions()
        {
            return _count;
        }
    }
}
