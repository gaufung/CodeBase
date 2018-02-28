package main

import "fmt"

func main() {
	var c1 complex64 = 4 + 10i

	fmt.Printf("The value is: %v\n", c1)
	fmt.Printf("The value real part is: %g\n", real(c1))
	fmt.Printf("The value's image part is: %g\n", imag(c1))
}
