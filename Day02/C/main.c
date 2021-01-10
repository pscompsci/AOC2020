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

int count_occurence(const char *password, char letter)
{
    size_t count = 0;
    while(*password != '\0') {
        count += *password++ == letter;
    }
    return count;
}

int str_to_int(char *line, int offset, int length)
{
    char temp[length + 1];
    strncpy(temp, line + offset, length);
    temp[length + 1] = '\0';
    return atoi(temp);
}

int index_of(char *line, char delim)
{
    int length = sizeof(line)/sizeof(char);
    for (int i = 0; i < length; i++) {
        if (line[i] == delim)
            return i;
    }
    return -1;
}

char *get_password(char *line, int offset)
{
    int length = sizeof(line)/sizeof(char);
    char password[length - offset];
    strcpy(password, line + offset + 1);
}

int isValidPart1(char *ptr)
{
    char *line = strdup(ptr);

    int idxDash = index_of(line, '-');
    int idxColon = index_of(line, ':');

    int minVal = str_to_int(line, 0, idxColon);
    int maxVal = str_to_int(line, idxDash + 1, idxColon - 1 - idxDash);

    char letter[2];
    strncpy(letter, line + idxColon - 1, 2);
    letter[1] = '\0';

    char *password = get_password(line, idxColon);
    int count = count_occurence(password, *letter);

    free(line);
    
    if (minVal <= count && count <= maxVal)
        return 1;

    return 0;
}

int isValidPart2(char *ptr)
{
    char *line = strdup(ptr);

    int idxDash = index_of(line, '-');
    int idxColon = index_of(line, ':');

    int pos1 = str_to_int(line, 0, idxColon);
    int pos2 = str_to_int(line, idxDash + 1, idxColon - 1 - idxDash);

    char letter[2];
    strncpy(letter, line + idxColon - 1, 2);
    letter[1] = '\0';

    char *password = get_password(line, idxColon);

    char letterPos1[2];
    strncpy(letterPos1, password + pos1, 2);
    letterPos1[1] = '\0';

    char letterPos2[2];
    strncpy(letterPos2, password + pos2, 2);
    letterPos2[1] = '\0';

    int count = 0;

    if (strcmp(letterPos1,letter))
        count++;

    if (strcmp(letterPos2,letter))
        count++;

    free(line);

    if (count == 1)
        return 1;
    return 0;
}

int main(int argc, char **argv)
{
    const char *in_file_path = argv[1];

    char *input = load_file(in_file_path);
    int init_size = strlen(input);
	char delim[] = "\n";

	char *ptr = strtok(input, delim);

    int part1Counter = 0;
    int part2Counter = 0;

	while(ptr != NULL)
	{
		part1Counter += isValidPart1(ptr);
        part2Counter += isValidPart2(ptr);
		ptr = strtok(NULL, delim);
	}

    printf("Part 1 valid passwords: %d\n", part1Counter);
    printf("Part 2 valid passwords: %d\n", part2Counter);

    free(input);
    free(ptr);
}