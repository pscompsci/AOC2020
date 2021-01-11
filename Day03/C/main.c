#include <stdlib.h>
#include <stdio.h>
#include <string.h>

char *load_file(const char *filepath)
{
    // Note: I know the file format is ok, so skipping error checking here
    FILE *f = fopen(filepath, "r");
    fseek(f, 0, SEEK_END);
    long m = ftell(f);
    char *buffer = malloc(m);
    fseek(f, 0, SEEK_SET);
    fread(buffer, 1, m, f);
    fclose(f);
    return buffer;
}

int find_line_length(const char *input)
{
    for (int i = 0; i < strlen(input); i++)
    {
        if (input[i] == '\n')
            return i + 1;
    }
}

int count_lines(const char*input)
{
    int lines = 0;
    for (int i = 0; i < strlen(input); i++)
    {
        if (input[i] == '\n')
            lines++;
    }
    return lines;
}

unsigned long long trees_for_route(const char *input, int row_step, int col_step)
{
    int row = 0;
    int col = 0;
    unsigned long long trees = 0;

    int lines = count_lines(input);
    int line_length = find_line_length(input);

    while (row < lines) {
        if (col >= (line_length - 1)) {
            col -= (line_length - 1);
        }
        int position = row * line_length + col;
        char value = input[position];
        if (value == '#') {
            trees++;
        }
        row += row_step;
        col += col_step;
        // printf("(%d, %d),\n", row, col);
    }

    return trees;
}

int main(int argc, char **argv)
{
    if (argc < 2) {
        fprintf(stderr, "USAGE: ./a.out <input.txt>\n");
        fprintf(stderr, "ERROR: expected input filepath\n");
        exit(1);
    }
    char *filepath = argv[1];
    char *input = load_file(filepath);

    // char hash = input[31];
    // printf("%c\n", hash);

    unsigned long long run1 = trees_for_route(input, 1, 1);
    unsigned long long run2 = trees_for_route(input, 1, 3);  // Part 1
    unsigned long long run3 = trees_for_route(input, 1, 5);  
    unsigned long long run4 = trees_for_route(input, 1, 7);  
    unsigned long long run5 = trees_for_route(input, 2, 1);  
    unsigned long long part2 = run1 * run2 * run3 * run4 * run5;
    
    printf("Part 1 Trees: %d\n", run2);
    printf("Part 2 Trees: %d\n", part2);
}