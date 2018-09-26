## AStar 【A* 算法】

* 启发式搜索算法
* 即A*算法，读音为A-star。

启发式搜索就是在状态空间中的搜索，首先对每一个搜索的位置进行评估，得到最好的位置，再从这个位置进行搜索直到目标。这样可以省略大量无谓的搜索路径，提高了效率。在启发式搜索中，对位置的估价是十分重要的。采用了不同的估价可以有不同的效果。
启发中的估价是用估价函数表示的，如：f(n) = g(n) + h(n)
其中f(n) 是节点n的估价函数，g(n)是在状态空间中从初始节点到n节点的实际代价，h(n)是从n到目标节点最佳路径的估计代价。在这里主要是h(n)体现了搜索的启发信息，因为g(n)是已知的。如果说详细点，g(n)代表了搜索的广度的优先趋势。但是当h(n) >> g(n)时，可以省略g(n)，而提高效率。
