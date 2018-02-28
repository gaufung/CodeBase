package main

import (
	"fmt"
	"strings"
)

func main() {
	var origS string = "hi there!"
	var newS string
	newS = strings.Repeat(origS, 5)
	fmt.Println(newS)
}
