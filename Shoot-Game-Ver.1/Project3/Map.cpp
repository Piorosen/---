#include <Windows.h>
#include <string>

#include "Map.h"
#include "Global.h"

void Map::Initialize(int x, int y, const char *path)
{
	m_path = path;

	m_sizeX = x;
	m_sizeY = y;

	loader = new MapLoader;
	loader->Initialize(x, y, m_path.c_str());
}

void Map::SetWorldProperty(int screenX, int screenY)
{
	m_screenX = screenX;
	m_screenY = screenY;
}


bool Map::GetCollide(int px, int py, int sx, int sy)
{
	double x = (px + sx + px + screenWidth / SCREEN_X) / 2.0 / (screenWidth / SCREEN_X);
	double y = (py + sy + py + screenHeight / SCREEN_Y) / 2.0 / (screenHeight / SCREEN_Y);


	if (!(0 <= x && x < SIZE_X)) {
		return true;
	}
	else if (!(0 <= y && y < SIZE_Y)) {
		return true;
	}
	//
	//std::wstring str = L"";
	//str = to_wstring(x) + L" " + to_wstring(y) + L" "
	//	+ to_wstring(mapdata[(int)y][(int)x].Move)+ L"\n";
	//OutputDebugString(str.c_str());

	//FILE* file;
	//fopen_s(&file, "C:\\Map\\Check.txt", "wt+");
	//for (int y = 0; y < m_sizeY; y++) {
	//	for (int x = 0; x < m_sizeX; x++) {
	//		

	//		fprintf(file, "%d / ", mapdata[y][x].Move == true ? 1 : 0);

	//	}
	//	fprintf(file, "\n");
	//}
	//fclose(file);
	return !mapdata[(int)y][(int)x].Move;
}

bool Map::GetCollide(int x, int y)
{
	return !mapdata[y][x].Move;
}

void Map::Shutdown()
{
	loader->Shutdown();
}

void Map::MapReLoad(int x, int y, const char *filename)
{
	loader->Shutdown();
	loader->Initialize(x, y, m_path.c_str());
	loader->Load(filename, mapdata);
}

void Map::MapReLoad(const char *filename)
{
	loader->Load(filename, mapdata);
}
void Map::GetMapData(MapData **& data)
{
	data = mapdata;
}



Map::~Map()
{
}
