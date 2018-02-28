package main

import "fmt"

func main(){
	fmt.Println("In main before calling greeting")
	greeting()
	fmt.Println("In main after calling greeting")
}
func greeting(){
	fmt.Println("In greeting: Hi!!!")
}
