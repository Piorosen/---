#pragma once
#include <vector>
#include <list>

using namespace std;

class Data {
public:
	int x;
	int y;
	long long time;
};


class MusicReader {
private:
	vector<Data> list;


public:

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


	std::vector<Data> GetMusic(const char* path) {
		list.clear();

		std::ifstream file(path);

		Data d;
		d.time = 0;
		d.x = 0;
		d.y = 0;
		
		int count = 0;

		file >> count;

		char data[100];

		for (int i = 0; i < count; i++) {
			char token = '/';

			file >> data;
			auto var = split(data, token);

			d.time = atoll(var[0].c_str());
			d.x = atoi(var[1].c_str());
			d.y = atoi(var[2].c_str());
			list.push_back(d);

		}
		file.close();
		return list;
	}


};