open System
// 7.1.1
let rec fibo n =
    match n with
    | 0 -> n 
    | 1 -> n
    | _ -> fibo (n-1) + fibo (n-2)

// 7.1.2
let rec sum n = 
    match n with
    | 1 -> 1
    | _ -> n + sum(n - 1)
    
printfn "%d" (sum 5)

// 7.1.3
let rec sum2 = function 
 | (m,0) -> m
 | (m,n) -> m + n + sum2 (m, n - 1)