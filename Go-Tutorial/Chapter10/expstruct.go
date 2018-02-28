package main

import "fmt"
import "./structpack"

func main(){
	struct1 := new(structpack.ExpStruct)
	struct1.Mf2=15.9
	struct1.Mi1 = 10

	fmt.Printf("Mi1 = %d\n", struct1.Mi1)
	fmt.Printf("Mf1 = %f\n", struct1.Mf2)
}
