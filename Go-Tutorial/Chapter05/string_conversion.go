package main

import (
	"fmt"
	"os"
	"strconv"
)

func main() {
	var orig string = "ABC"
	if an, err := strconv.Atoi(orig); err != nil {
		fmt.Printf("original %s is not a integer\n", orig)
		os.Exit(1)
	} else {
		fmt.Print(an)
	}

}
