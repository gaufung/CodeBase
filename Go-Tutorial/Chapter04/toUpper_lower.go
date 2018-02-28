package main

import (
	"fmt"
	"strings"
)

func main() {
	var str string = "Hey, how are you George"
	fmt.Printf("original string is: %s\n", str)
	fmt.Printf("the upper string is: %s\n", strings.ToUpper(str))
	fmt.Printf("the lower string is: %s\n", strings.ToLower(str))

}
