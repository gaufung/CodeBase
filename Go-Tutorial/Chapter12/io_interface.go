package main

import (
	"fmt"
	"bufio"
	"os"
)

func main(){
	fmt.Fprintf(os.Stdout, "%s\n", "Hello world! - unbuffered")
	buf := bufio.NewWriter(os.Stdout)
	fmt.Fprintf(buf, "%s\n", "hello world - buffered")
	buf.Flush()
}
