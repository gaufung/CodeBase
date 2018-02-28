package main

import (
	"fmt"
	. "./pack1"
)


func main(){
	var test1 string
	test1 = RetrunStr()
	fmt.Printf("ReturnStr from package1: %s\n", test1)
	fmt.Printf("Integer from packag1: %d\n", Pack1Int)
}