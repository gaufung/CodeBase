package main

import (
	"fmt"
	"strconv"
)

type TwoInt struct {
	a int
	b int
}

func (tn *TwoInt) String() string{
	return "("+strconv.Itoa(tn.a)+"/"+strconv.Itoa(tn.b)+")"
}

func main(){
	two1 := new(TwoInt)
	two1.a=12
	two1.b=10
	fmt.Printf("two1 is: %v\n", two1)
	fmt.Printf("two1 is:",two1)
	fmt.Printf("two1 is: %T\n", two1)
	fmt.Printf("two1 is: %#v\n", two1)
}