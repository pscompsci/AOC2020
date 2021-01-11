package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func loadFile(filename string) ([]string, error) {
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

func isValidPart1(line, letter string, min, max int) bool {
	count := strings.Count(line, letter)
	if min <= count && count <= max {
		return true
	}
	return false
}

func isValidPart2(line string, letter byte, pos1, pos2 int) bool {
	count := 0
	if line[pos1] == letter {
		count++
	}
	if line[pos2] == letter {
		count++
	}

	if count == 1 {
		return true
	}
	return false
}

func main() {
	lines, err := loadFile("../input.txt")
	if err != nil {
		fmt.Printf("ERROR: %v\n", err.Error())
		os.Exit(1)
	}

	lineCount := 0
	part1Counter := 0
	part2Counter := 0

	for _, ln := range lines {
		lineCount++
		idxColon := strings.Index(ln, ":")
		leftPart := ln[:idxColon]
		// Not trimming here to leave the space (index 0) at the start, since we want indexing from 1
		rightPart := ln[idxColon+1:]

		idxDash := strings.Index(leftPart, "-")
		idxSpace := strings.Index(leftPart, " ")

		min, _ := strconv.Atoi(leftPart[:idxDash])
		max, _ := strconv.Atoi(leftPart[idxDash+1 : idxSpace])
		letter := leftPart[idxSpace+1]

		if isValidPart1(rightPart, string(letter), min, max) {
			part1Counter++
		}

		if isValidPart2(rightPart, letter, min, max) {
			part2Counter++
		}
	}

	fmt.Printf("Total lines %d. Valid passwords for part 1: %d\n", lineCount, part1Counter)
	fmt.Printf("Total lines %d. Valid passwords for part 2: %d\n", lineCount, part2Counter)
}
