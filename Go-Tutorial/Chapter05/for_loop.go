package main

import "fmt"

func main() {
	i := 0
START:
	fmt.Printf("The coutner is %d\n", i)
	i++
	for i < 15 {
		goto START
	}
}
