package main

import "fmt"

func a(){
	i := 0
	defer fmt.Println(i)
	i++
	return
}

func f(){
	for i:=0; i< 5; i++{
		defer fmt.Printf("%d\n", i)
	}
}

func main(){
	//a()
	f()
}