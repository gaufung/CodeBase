package main

import "fmt"

var a = "g"

func main() {
	m()
	m()
	n()

}
func n() { fmt.Print(a) }

func m() {
	a := "0"
	fmt.Println(a)
}
