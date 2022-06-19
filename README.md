# HashPuzzleSolution

This was a project to test if it is viable to generate random SHA256 hashes to give a client "busy work" to prevent flooding a server and require an approximate "time to finish" based on difficulty.

It sort of works, but it's way too "rude" for what I'm intending.  I wanted to use this as the core of a game where players complete "tasks" by generating hashes and when they found the "answer" they were allowed into the next part of the puzzle.

My first attempt was at a perfect match of order without gaps.
* 2,3,4,5 must all exist in order without gaps in array 0,1,2,3,4,5,6,7,8

The difficulty of this strategy scales too quickly.

My next attempt was to simply match existence at any position in the array
* 2,3,4,5 is "good" against array 3,2,6,4,7,5,1,9,8

This worked better as you could control the scaling better

Testing on my machine showed a search of random N matches led to T time
| matches | time |
| ------------- | ------------- |
| 1 | <1 (ms) |
| 2  | <1 (ms) |
| 3  | ~2 (ms) |
| 4  | ~5 (ms) |
| 5  | ~367 (ms) |
| 6  | ~968 (ms) |
| 7  | ~21 (sec) |
| 8  | ~1 (min) |
| 9  | ~2 (min) |

But the whole concept is flawed for my purposes because it's not cool to burn 100% of a CPU core on someone's computer just to simulate a difficult task in a game.  Regardless of the flaws I wanted to preserve my work and make it available to anyone who is interested.
