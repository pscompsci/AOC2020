package main

import (
	"bufio"
	"fmt"
	"os"
)

func loadFileAsSlice(filename string) ([]string, error) {
	lines := []string{}
	file, err := os.Open(filename)
	if err != nil {
		return lines, err
	}
	defer file.Close()
	scanner := bufio.NewScanner(file)
	scanner.Split(bufio.ScanLines)
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}
	return lines, nil
}

// This is a more memory efficient approach than the initial approach used in
// the C# implementation.
func treesForRoute(course []string, row, col int) int {
	r := 0
	c := 0
	trees := 0

	cols := len(course[0])

	for r < len(course) {
		if c >= cols {
			c -= cols
		}
		if course[r][c] == '#' {
			trees++
		}
		r += row
		c += col
	}
	return trees
}

func main() {
	input, err := loadFileAsSlice("../input.txt")
	if err != nil {
		fmt.Printf("Error: %v\n", err.Error())
		os.Exit(1)
	}

	run1 := treesForRoute(input, 1, 1)
	run2 := treesForRoute(input, 1, 5)
	run3 := treesForRoute(input, 1, 3)
	run4 := treesForRoute(input, 1, 7)
	run5 := treesForRoute(input, 2, 1)

	fmt.Printf("Part 1: %d trees\n", run3)
	fmt.Printf("Part 2: %d trees\n", run1*run2*run3*run4*run5)
}
