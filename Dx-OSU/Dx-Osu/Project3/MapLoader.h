#pragma once
#include <iostream>
#include <vector>
#include <fstream>

using namespace std;

struct MapData {
	int Filed = 0;
	bool Move = true;

	int TextureID = 0;
	float Alpha = 1.0;
	float Red = 1.0;
	float Green = 1.0;
	float Blue = 1.0;
};

// Filed/Move/TextureID/Alpha/Red/Green/Blue(' '))
class MapLoader
{
private:
	MapData** m_mapdata;
	unsigned int m_width;
	unsigned int m_height;
	std::string path;

	vector<string> split(string strTarget, char token)
	{
		int     nCutPos;
		int     nIndex = 0;
		vector<string> strResult;

		while ((nCutPos = strTarget.find_first_of(token)) != strTarget.npos)
		{
			if (nCutPos > 0)
			{
				strResult.push_back(strTarget.substr(0, nCutPos));
			}
			strTarget = strTarget.substr(nCutPos + 1);
		}

		if (strTarget.length() > 0)
		{
			strResult.push_back(strTarget.substr(0, nCutPos));
		}

		return strResult;
	}
public:
	MapLoader();
	
	void Initialize(unsigned int, unsigned int, const char*);
	void Shutdown();

	void Load(const char*, MapData**&);

	MapData** GetMapData() const;

	virtual ~MapLoader();


};
