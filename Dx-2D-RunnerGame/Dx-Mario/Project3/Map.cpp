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


bool Map::GetCollide(float px, float py, float sx, float sy)
{
	bool result = true;

	int max_x = (px + sx -1) / (screenWidth / SCREEN_X);
	int max_y = (py + sx -1) / (screenHeight / SCREEN_Y);
	
	int min_x = (px) / (screenWidth / SCREEN_X);
	int min_y = (py) / (screenHeight / SCREEN_Y);

	max_x = max_x >= 100 ? max_x - 100 : max_x;
	max_y = max_y >= 100 ? max_y - 100 : max_y;
	min_x = min_x >= 100 ? min_x - 100 : min_x;
	min_y = min_y >= 100 ? min_y - 100 : min_y;


	if (!(0 <= min_x && max_x < SIZE_X)) {
		return true;
	}
	else if (!(0 <= min_y && max_y < SIZE_Y)) {
		return true;
	}


	result = mapdata[min_y][min_x].Move ? result : false;
	result = mapdata[min_y][max_x].Move ? result : false;
	result = mapdata[max_y][min_x].Move ? result : false;
	result = mapdata[max_y][max_x].Move ? result : false;



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

	return !result;
}

bool Map::GetCollide(D3DXVECTOR2 position, D3DXVECTOR2 size)
{
	return GetCollide(position.x, position.y, size.x, size.y);
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
