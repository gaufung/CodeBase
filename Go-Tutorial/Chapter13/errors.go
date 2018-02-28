package main

import (
	"errors"
	"fmt"
)

var errNotFound error = errors.New("Not Found error")

func main(){
	fmt.Printf("error: %v", errNotFound)
}
