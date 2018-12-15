#pragma once

#include <D3DX10math.h>


class Character {
private:

public:
	virtual void Shutdown() = 0;

protected:
	D3DXVECTOR2 Position;
	int HealthPoint;
};