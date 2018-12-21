#pragma once
#include <Windows.h>

#include "MapLoader.h"


class Map
{
private:
	std::string m_path;

	MapData** mapdata;
	MapLoader* loader;

	int m_sizeX;
	int m_sizeY;
	int m_screenX;
	int m_screenY;

public:
	void Initialize(int, int, const char *path);
	
	void SetWorldProperty(int, int);
	
	bool GetCollide(int, int, int, int);
	bool GetCollide(int, int);
	void Shutdown();

	void MapReLoad(int, int, const char *);
	void MapReLoad(const char *);
	
	void GetMapData(MapData** &data);

	virtual ~Map();

};