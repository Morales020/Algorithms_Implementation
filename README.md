
# Implementing Famous Algorithms

## Overview

This repository contains the implementation of some famous algorithms:

1. ### `Heap-Sort Algorithm`: A sorting algorithm that uses a binary heap to sort a sequence of numbers.
2. ### `Kruskal's Algorithm`: A graph algorithm used to find the Minimum Spanning Tree (MST) of a network.
---
## Table of Contents

- ## [Heap-Sort Algorithm](#heap-sort-algorithm)
  - [Algorithm Description](#algorithm-description)
  - [Steps Involved in Heap-Sort](#steps-involved-in-heap-sort)
  - [Time Complexity Analysis](#time-complexity-analysis)
  - [Example](#example)
- ## [Kruskal's Algorithm](#kruskals-algorithm)
  - [Algorithm Description](#algorithm-description-1)
  - [Steps Involved in Kruskal's Algorithm](steps-involved-in-kruskal's-algorithm)
  - [Time Complexity Analysis](#time-complexity-analysis-1)
  - [Example](#example-1)

---
# Heap-Sort Algorithm

### Algorithm Description

Heap-Sort is a comparison-based sorting algorithm that works by converting an array into a binary heap and then repeatedly extracting the minimum element from the heap to build a sorted array.

---

### Steps Involved in Heap-Sort
1.  ### `Heapify Algorithm`:
   Maintains the max-heap property for a subtree rooted at a given index. Ensures the largest value is at the root.

   ```
   Heapify(arr, n, i):
       largest = i               # Initialize largest as root
       left = 2 * i + 1          # Left child index
       right = 2 * i + 2         # Right child index

       if left < n and arr[left] > arr[largest]:
           largest = left

       if right < n and arr[right] > arr[largest]:
           largest = right

       if largest != i:
           Swap(arr[i], arr[largest])
           Heapify(arr, n, largest)
   ```

2. ### `Build-Max-Heap Algorithm`:
   Converts an unsorted array into a max-heap.

   ```
   BuildMaxHeap(arr):
       n = len(arr)
       for i from (n // 2 - 1) to 0:  # Start from last non-leaf node
           Heapify(arr, n, i)
   ```

3. ### `Heap-Sort Algorithm`:
   Sorts the array by repeatedly extracting the maximum element.

   ```
   HeapSort(arr):
       BuildMaxHeap(arr)          # Step 1: Build the max-heap
       n = len(arr)
       for i from (n - 1) to 1:
           Swap(arr[0], arr[i])   # Move max element to end
           Heapify(arr, i, 0)     # Reduce the heap size and heapify
   ```

---

### Time Complexity Analysis

### `Heapify Algorithm`:
- **Time Complexity**: `O(log n)` per call since the height of the heap is proportional to `(log n)`.

### `Build-Max-Heap Algorithm`:
- **Time Complexity**: `O(n)`, as the cost of heapifying nodes decreases for deeper levels (fewer nodes at higher depths).

### `Heap-Sort Algorithm`:
- **Time Complexity**: 
  - **Best Case**: `O(n log n)`, as it involves building the heap and sorting.
  - **Average Case**: `O(n log n)`, due to the heapify operation applied (log n) times per element.
  - **Worst Case**: `O(n log n)`, when the heapify operation requires full reorganization of the heap.
---

### Example

Sample Input:
```
Enter the number of elements in the array: 5
Enter the elements of the array:
Element 1: 10
Element 2: 4
Element 3: 6
Element 4: 3
Element 5: 8
```

Sample Output:
```
Sorted array: 3 4 6 8 10
```
---


# Kruskal's Algorithm

### Algorithm Description

Kruskal’s algorithm finds the Minimum Spanning Tree (MST) of a graph by:

1. Sorting all edges of the graph in non-decreasing order of their weight.
2. Iterating through the sorted edges and adding them to the MST if they don’t form a cycle (using a union-find data structure to check for cycles).

---

### Steps Involved in Kruskal's Algorithm
1. ### `Sort All Edges:`
   - Sort all edges of the graph in non-decreasing order of their weights.

2. ### `Union-Find Data Structure:`
   - **Find Operation:** Determines the root or representative of a set with path compression for optimization.
   - **Union Operation:** Merges two sets based on rank to maintain efficiency.

3. ### `Construct MST:`
   - Initialize an empty MST.
   - Iterate through the sorted edges and add each edge to the MST if it does not form a cycle.
   - Use the Union-Find structure to check and avoid cycles.

---

### Time Complexity Analysis

1.  ### `Sorting:`
    *   **Description:** The algorithm begins by sorting the edges of the graph by their weights in ascending order.
    *   **Complexity:** The time complexity for sorting the edges is given as [ $E log(E)$ ] , where $E$ is the number of edges.<br>This is is equal to [ $E log(V^2)$ ] which simplifies to  [ $Θ(E log(V))$ ] where $V$ is the number of vertices.
2.  ### `Make-Set:`
    *   **Description:** For each vertex, a separate set is created.
    *  **Complexity:** When using a "normal array" data structure for the set, this takes [ $Θ(V)$ ] . When using a disjoint set forest, it takes time of `V * Make-Set Time`.
3.  ### `Find-Set:`
    *   **Description:**  For each edge, we need to determine which set its vertices belong to.
    *   **Complexity:** When using a "normal array" data structure for the set, this takes  [ $Θ(E)$ ] . When using a disjoint set forest, it takes time of `E * Find-Set Time`.
4.  ### `Union:`
    *   **Description:** If the two vertices from an edge are in different sets, these two sets are combined to represent connected components of the spanning tree.
    *  **Complexity:** When using a "normal array" data structure for the set, this takes [ $Θ(V^2)$ ] . When using a disjoint set forest, it takes time of `V * Union Time`.

### `Total Complexity (with Normal Array):`

*   The sum of the complexities is:  $Θ(E log(V)) +  Θ(V) + Θ(E) +  Θ(V^2)$.
*   Simplifying (assuming E can be as large as ($V^2$), the dominant terms are the [ $E log(V)  and  V^2 ] )$ , the total complexity is  [ $Θ(E log(V) + V^2)$ ].

---

### Example

Sample Input:
```
Enter the number of vertices:
4
Enter the edges in the format: Source Destination Weight
0 1 10
0 2 6
0 3 5
1 3 15
2 3 4
done
```

Sample Output:
```
Edges in the Minimum Spanning Tree:
(2, 3) - Weight: 4
(0, 3) - Weight: 5
(0, 1) - Weight: 10
Total Weight of the MST: 19
```
