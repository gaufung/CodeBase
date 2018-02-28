package main

import (
	"fmt"
)

const c = "C"

var v int = 5

type T struct{}

func init() {
	fmt.Println("init")
}
func main() {
	var a int
	func1()
	t := new(T)
	t.method1()
	fmt.Println(a)

}
func (t T) method1() {

}
func func1() {
}
