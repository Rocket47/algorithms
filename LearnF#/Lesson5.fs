open System
let notDivisible (n, m) = m % n = 0

let prime n = 
  let rec loop iterator = 
    if iterator = n/2 then true
    elif n % iterator = 0 then false
    else loop (iterator + 1)
  loop 2