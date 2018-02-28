package main

import "fmt"

var a string = "b"

func main() {
	a = "G"
	fmt.Println(a)
	f1()
}
func f1() {
	a := "0"
	print(a)
	f2()

}
func f2() {
	print(a)
}
