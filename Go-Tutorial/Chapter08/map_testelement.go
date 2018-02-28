package main

import (
	"fmt"
)

func main() {
	var value int
	var isPresent bool

	map1 := make(map[string]int)

	map1["new delhi"] = 55
	map1["Beijing"] = 20
	map1["washington"] = 25

	value, isPresent = map1["Beijing"]
	if isPresent {
		fmt.Printf("The value of \" beijing \" in map1 is: %d\n", value)
	} else {
		fmt.Print("map1 does not contain beijing")
	}
	value, isPresent = map1["paris"]
	if isPresent {
		fmt.Printf("The value of \" paris \" in map1 is: %d\n", value)
	} else {
		fmt.Printf("Value is: %d\n", value)
	}
	delete(map1, "washington")
	value, isPresent = map1["washington"]
	if isPresent {
		fmt.Printf("The value of \" washington \" in map1 is: %d\n", value)
	} else {
		fmt.Printf("Value is: %d\n", value)
	}
}
