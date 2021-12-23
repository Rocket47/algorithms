open System

let rec pow = function
| (s, 0) -> ""
| (s, n) -> s + pow (s, n - 1)

let rec isIthChar = function
| (s, n, c) when n < 0 -> false
| (s, n, c) when n > (String.length s) -> false
| (s, n, c) -> s.[n] = c

let rec occFromIth (str, number, chr) = 
  (let rec counter = function
    | (s, n, c, count) when (n = (String.length s)) -> count
    | (s, n, c, count) when ((string s).[n] = c) -> counter(s, n + 1, c, count + 1)
    | (s, n, c, count) when ((string s).[n] <> c) -> counter(s, n + 1, c, count)
    | _ -> 0

counter(str, number, chr, 0))