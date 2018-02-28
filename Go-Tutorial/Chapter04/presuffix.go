package main

import (
	"fmt"
	"strings"
)

func main() {
	var str string = "This is an example of strings"
	fmt.Printf("T/F? Does the string \" %s \" has a prefix %s? ", str, "Th")
	fmt.Printf("%t\n", strings.HasPrefix(str, "Th"))
}
