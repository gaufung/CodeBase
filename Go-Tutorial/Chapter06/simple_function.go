package main

import "fmt"

func main(){
	fmt.Printf("Mulitply 2 * 5 * 6 = %d\n", Multiply3Nums(2, 5, 6))
}

func Multiply3Nums(a, b, c int) int{
	return a*b*c
}
