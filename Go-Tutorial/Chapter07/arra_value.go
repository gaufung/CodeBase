package main

import "fmt"

func arr_chage(a [2]int){
	a[0]= -1
}

func main(){
	var a [2]int
	for _, val := range a{
		fmt.Print(val, " ")
	}
	arr_chage(a)
	for _, val := range a{
		fmt.Print(val, " ")
	}
}
