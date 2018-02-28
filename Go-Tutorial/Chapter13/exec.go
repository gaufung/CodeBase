package main

import (
	"os"
	"fmt"
)

func main(){
	env := os.Environ()
	proAttr := &os.ProcAttr{
		Env:env,
		Files:[]*os.File{
			os.Stdin,
			os.Stdout,
			os.Stderr,
		},
	}

	pid, error := os.StartProcess("/bin/ls", []string{"ls", "-l"}, proAttr)
	if error!=nil{
		fmt.Printf("Error %v starting process!", error)
		os.Exit(1)
	}
	fmt.Printf("The process id is %v", pid)

}
