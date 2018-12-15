#include "CircleClass.h"

bool CircleClass::Initialize(ID3D11Device* device, D3DXVECTOR4 color, D3DXVECTOR3 position, float radius)
{
	bool result;


	// Initialize the vertex and index buffers.
	result = InitializeBuffers(device, color, position, radius);
	if (!result)
	{
		return false;
	}

	return true;
}


void CircleClass::Shutdown()
{
	// Shutdown the vertex and index buffers.
	ShutdownBuffers();

	return;
}


void CircleClass::Render(ID3D11DeviceContext* deviceContext, bool filled)
{
	// Put the vertex and index buffers on the graphics pipeline to prepare them for drawing.
	RenderBuffers(deviceContext, filled);

	return;
}


int CircleClass::GetIndexCount()
{
	return m_vertexCount;
}


bool CircleClass::InitializeBuffers(ID3D11Device* device, D3DXVECTOR4 color, D3DXVECTOR3 start, float radius)
{
	std::vector<VertexType> verticles;
	unsigned long* indices;
	D3D11_BUFFER_DESC vertexBufferDesc;
	D3D11_SUBRESOURCE_DATA vertexData;
	HRESULT result;

	int f = 1 - radius;
	int ddF_x = 0;
	int ddF_y = -2 * radius;
	int x = 0;
	int y = radius;

	//Add points the loop will not add

	verticles.push_back(VertexType(D3DXVECTOR3(start[0], start[1] + radius, 0), color)); // bottom
	verticles.push_back(VertexType(D3DXVECTOR3(start[0], start[1] - radius, 0), color)); // top
	verticles.push_back(VertexType(D3DXVECTOR3(start[0] + radius, start[1], 0), color)); // right
	verticles.push_back(VertexType(D3DXVECTOR3(start[0] - radius, start[1], 0), color)); // left

	while (x < y)
	{
		if (f >= 0)
		{
			y--;
			ddF_y += 2;
			f += ddF_y;
		}
		x++;
		ddF_x += 2;
		f += ddF_x + 1;

		verticles.push_back(VertexType(D3DXVECTOR3(start[0] + x, start[1] + y, 0), color)); // 4. quarter
		verticles.push_back(VertexType(D3DXVECTOR3(start[0] - x, start[1] + y, 0), color)); // 3. quarter
		verticles.push_back(VertexType(D3DXVECTOR3(start[0] + x, start[1] - y, 0), color)); // 1. quarter
		verticles.push_back(VertexType(D3DXVECTOR3(start[0] - x, start[1] - y, 0), color)); // 2. quarter
		verticles.push_back(VertexType(D3DXVECTOR3(start[0] + y, start[1] + x, 0), color)); // 4. quarter
		verticles.push_back(VertexType(D3DXVECTOR3(start[0] - y, start[1] + x, 0), color)); // 3. quarter
		verticles.push_back(VertexType(D3DXVECTOR3(start[0] + y, start[1] - x, 0), color)); // 1. quarter
		verticles.push_back(VertexType(D3DXVECTOR3(start[0] - y, start[1] - x, 0), color)); // 2. quarter
	}

	//float left, right, top, bottom;

	//left = Lib_DIRECTXTOWINDOWX(start.x);
	//right = Lib_WINDOWSIZEX(left, float);
	//top = Lib_DIRECTXTOWINDOWY(start.y);
	//bottom = Lib_WINDOWSIZEY(top, size.y);

	m_vertexCount = verticles.size();

	vertexBufferDesc.Usage = D3D11_USAGE_DEFAULT;
	vertexBufferDesc.ByteWidth = sizeof(VertexType) * m_vertexCount;
	vertexBufferDesc.BindFlags = D3D11_BIND_VERTEX_BUFFER;
	vertexBufferDesc.CPUAccessFlags = 0;
	vertexBufferDesc.MiscFlags = 0;
	vertexBufferDesc.StructureByteStride = 0;

	// Give the subresource structure a pointer to the vertex data.
	vertexData.pSysMem = verticles.data();
	vertexData.SysMemPitch = 0;
	vertexData.SysMemSlicePitch = 0;

	// Now create the vertex buffer.
	result = device->CreateBuffer(&vertexBufferDesc, &vertexData, &m_vertexBuffer);

	if (FAILED(result))
	{
		return false;
	}

	return true;
}


void CircleClass::ShutdownBuffers()
{
	// Release the vertex buffer.
	if (m_vertexBuffer)
	{
		m_vertexBuffer->Release();
		m_vertexBuffer = 0;
	}

	return;
}


void CircleClass::RenderBuffers(ID3D11DeviceContext* deviceContext, bool filled)
{
	unsigned int stride;
	unsigned int offset;

	// Set vertex buffer stride and offset.
	stride = sizeof(VertexType);
	offset = 0;

	// Set the vertex buffer to active in the input assembler so it can be rendered.
	deviceContext->IASetVertexBuffers(0, 1, &m_vertexBuffer, &stride, &offset);

	// Set the type of primitive that should be rendered from this vertex buffer, in this case triangles.
	deviceContext->IASetPrimitiveTopology(filled ? D3D11_PRIMITIVE_TOPOLOGY_LINESTRIP : D3D11_PRIMITIVE_TOPOLOGY_POINTLIST);

	return;
}