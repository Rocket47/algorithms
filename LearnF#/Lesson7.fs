// 20.3.1
let vat n x = x + ((float n) * x / 100.0)

// 20.3.2
let unvat n x = x / ((100.0 + float n) / 100.0)

// 20.3.3
let rec min f = 
    (let rec loop number =
        if ((f number) = 0) then
            number
        else 
            loop (number + 1)
    loop 1)





