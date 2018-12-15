
#include "MapLoader.h"



MapLoader::MapLoader()
{
	m_mapdata = 0;
	path.operator=('\0');
}

void MapLoader::Initialize(unsigned int width, unsigned int height, const char * path)
{
	m_mapdata = new MapData*[height];
	for (int i = 0; i < height; i++) {
		m_mapdata[i] = new MapData[width];
	}

	m_width = width;
	m_height = height;
	this->path = path;
}

void MapLoader::Shutdown()
{
	for (int i = 0; i < m_height; i++) {
		delete m_mapdata[i];
	}
	delete m_mapdata;
}

void MapLoader::Load(const char *name, MapData** &returndata)
{
	if (!m_mapdata)
		return;

	path += name;
	std::ifstream file(path);
	
	
	char data[100];

	for (int i = 0; i < m_width * m_height; i++) {
		char token = '/';

		file >> data;
		auto var = split(data, token);
		
		m_mapdata[i / m_width][i % m_width].Filed = atoi(var[0].c_str());
		m_mapdata[i / m_width][i % m_width].Move = atoi(var[1].c_str()) == 0 ? false : true;
		m_mapdata[i / m_width][i % m_width].TextureID = atoi(var[2].c_str());
		if (!m_mapdata[i / m_width][i % m_width].Move) {
			printf("Test");
		}
	}
	returndata = m_mapdata;
	file.close();
}


MapData** MapLoader::GetMapData() const
{
	return m_mapdata;
}

MapLoader::~MapLoader()
{
}
