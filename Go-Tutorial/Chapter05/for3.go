package main

import "fmt"

func main() {
	i := 5
	for {
		i = i - 1
		fmt.Printf("The variable i is now %d\n", i)
		if i < 0 {
			break
		}
	}

}
